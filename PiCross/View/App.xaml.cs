using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;


namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();

            var vm = new StartupVM();

            

            mainWindow.DataContext = vm;
            mainWindow.Show();
        }

        private void ViewExit()
        {
            Application.Current.Shutdown();
        }
    }
}
