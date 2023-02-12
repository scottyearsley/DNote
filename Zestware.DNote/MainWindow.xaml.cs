using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Components.WebView;

namespace Zestware.DNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Startup.Configure(Resources);
        }
        
        private void Handle_UrlLoading(object sender, UrlLoadingEventArgs urlLoadingEventArgs)
        {
            if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
            {
                urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
