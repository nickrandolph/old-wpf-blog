using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace TemplatingItems
{
    public partial class App : Application
    {
        void AppStartingUp(object sender, EventArgs e)
        {
            Window1 mainWindow = new Window1();
            mainWindow.Show();
        }
    }
}