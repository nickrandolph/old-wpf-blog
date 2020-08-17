// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.UI.Xaml;
using System;

namespace BarGraph.Desktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private Random random;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
        }

        private void ChangeData(object sender, RoutedEventArgs e)
        {
            DataSource source = (DataSource)RootGrid.Resources["source"];
            for (int i = 0; i < source.ValueCollection.Count; i++)
            {
                source.ValueCollection[i] = random.Next(10, 130);
            }
        }
    }
}
