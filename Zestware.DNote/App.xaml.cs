using System;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace Zestware.DNote
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon? _tb;
        
        protected override void OnActivated(EventArgs e)
        {
            _tb = (TaskbarIcon) FindResource("MyNotifyIcon");
        }
    }
}
