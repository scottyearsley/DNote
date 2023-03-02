using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace Zestware.DNote.WinHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly HotKey _hotKey = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            _ = (TaskbarIcon) FindResource("MyNotifyIcon");
            
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Top = -1000;
            Current.MainWindow.Show();
            Current.MainWindow.Visibility = Visibility.Collapsed;
            
            _hotKey.Register(Current.MainWindow, ShowWindowOnTop);
            
            base.OnStartup(e);
        }

        private void ShowWindowOnTop()
        {
            Current.MainWindow.Top = 100;
            Current.MainWindow.Show();
            Current.MainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _hotKey.Unregister();
            base.OnExit(e);
        }
    }
}
