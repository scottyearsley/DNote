using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
// ReSharper disable InconsistentNaming

namespace Zestware.DNote.WinHost;

public class HotKey
{
    // Registers a hot key with Windows.
    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
    
    // Unregisters the hot key with Windows.
    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
    private const int HOTKEY_ID = 9000;
    private const uint VK_O = 0x4E;
  
    //Modifiers:
    private const uint MOD_NONE = 0x0000; //(none)
    private const uint MOD_ALT = 0x0001; //ALT
    private const uint MOD_CONTROL = 0x0002; //CTRL
    private const uint MOD_SHIFT = 0x0004; //SHIFT
    private const uint MOD_WIN = 0x0008; //WINDOWS

    private IntPtr _windowHandle;
    private HwndSource _source;
    private Action? _callback;
    
    public void Register(Window window, Action callback)
    {
        _windowHandle = new WindowInteropHelper(window).Handle;
        _callback = callback;
        _source = HwndSource.FromHwnd(_windowHandle);
        _source.AddHook(HwndHook);
        
        if (!RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_ALT, VK_O))
        {
            throw new InvalidOperationException("Could not register the hot key.");
        };
    }

    public void Unregister()
    {
        _source.RemoveHook(HwndHook);
        UnregisterHotKey(_windowHandle, HOTKEY_ID);
    }

    private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        const int WM_HOTKEY = 0x0312;
        switch (msg)
        {
            case WM_HOTKEY:
                switch (wParam.ToInt32())
                {
                    case HOTKEY_ID:
                        int vkey = (((int)lParam >> 16) & 0xFFFF);
                        if (vkey == VK_O)
                        {
                            _callback?.Invoke();
                        }
                        handled = true;
                        break;
                }
                break;
        }
        return IntPtr.Zero;
    }
}
