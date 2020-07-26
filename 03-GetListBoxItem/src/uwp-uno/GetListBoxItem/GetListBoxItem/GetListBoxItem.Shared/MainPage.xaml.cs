using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GetListBoxItem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //    var cv = listBox.ItemsSource as ICollectionView;

        //    var vcs = this.Resources["allGods"] as CollectionViewSource;
        //    var view = vcs.View;
        //    listBox.ItemsSource = view;
        //}

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            GreekGod greekGod = (GreekGod)(listBox.Items[0]);
            ListBoxItem lbi1 = (ListBoxItem)(listBox.ContainerFromIndex(0));
            ListBoxItem lbi2 = (ListBoxItem)(listBox.ContainerFromItem(listBox.SelectedItem));

            var vcs = this.Resources["allGods"] as CollectionViewSource;
            var item = vcs.View.CurrentItem;
        }
    }
}
