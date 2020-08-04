using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace SelectedValueSample
{
    public partial class MyApp : Application
    {
        private void AppStartingUp(object sender, StartupEventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();
        }
    }
}