using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.AspNetCore.Components.WebView;

namespace Zestware.DNote.WinHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            KeyDown += OnButtonKeyUp;
            
            Startup.Configure(Resources);
        }

        private void OnButtonKeyUp(object? sender, KeyEventArgs e)
        {
            if (IsActive && e.Key == Key.Escape)
            {
                Hide();
            }
        }

        private void Handle_UrlLoading(object sender, UrlLoadingEventArgs urlLoadingEventArgs)
        {
            if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
            {
                urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
