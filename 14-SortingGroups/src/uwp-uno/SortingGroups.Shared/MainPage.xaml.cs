using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace SortingGroups
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var animals = new Animals().AnimalList;
            var groupedAnimals = from animal in animals
                                 orderby animal.Name
                                 group animal by animal.Category into g
                                 orderby g.Key
                                 select g;
            (this.Resources["cvs"] as CollectionViewSource).Source = groupedAnimals;
        }
    }
}
