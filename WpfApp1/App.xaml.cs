using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var twitchUserName = "yourname";
            var accessToken = "token";
            var channel = "channel";

            var mainWindow = new MainWindow();

            var bot = new BobbleBot(mainWindow, twitchUserName, accessToken, channel);

            Application.Current.MainWindow = mainWindow;
            mainWindow.InitializeComponent();
            MainWindow.Show();

        }
    }
}
