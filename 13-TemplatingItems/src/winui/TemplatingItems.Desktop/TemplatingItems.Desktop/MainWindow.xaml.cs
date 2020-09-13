using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TemplatingItems.Desktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

   }

    public class GreekTemplateSelector : DataTemplateSelector
    {
        private DataTemplate greekGodTemplate;

        public DataTemplate GreekGodTemplate
        {
            get { return greekGodTemplate; }
            set { greekGodTemplate = value; }
        }

        private DataTemplate greekHeroTemplate;

        public DataTemplate GreekHeroTemplate
        {
            get { return greekHeroTemplate; }
            set { greekHeroTemplate = value; }
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is GreekGod)
            {
                return GreekGodTemplate;
            }
            return GreekHeroTemplate;
        }
    }



    public class PlaceTemplateSelector : DataTemplateSelector
    {
        private DataTemplate washingtonTemplate;

        public DataTemplate WashingtonTemplate
        {
            get { return washingtonTemplate; }
            set { washingtonTemplate = value; }
        }

        private DataTemplate notWashingtonTemplate;

        public DataTemplate NotWashingtonTemplate
        {
            get { return notWashingtonTemplate; }
            set { notWashingtonTemplate = value; }
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            Place place = (Place)item;

            if (place.State == "WA")
            {
                return washingtonTemplate;
            }
            else
            {
                return notWashingtonTemplate;
            }
        }
    }

    public class GreekGodsAndHeros : ObservableCollection<object>
    {
        public GreekGodsAndHeros()
        {
            Add(new GreekGod("Aphrodite", "Goddess of love, beauty and fertility"));
            Add(new GreekGod("Apollo", "God of prophesy, music and healing"));
            Add(new GreekGod("Ares", "God of war"));
            Add(new GreekGod("Artemis", "Virgin goddess of the hunt"));
            Add(new GreekGod("Athena", "Goddess of crafts and the domestic arts"));
            Add(new GreekHero("Bellerophon"));
            Add(new GreekGod("Demeter", "Goddess of agriculture"));
            Add(new GreekGod("Dionysus", "God of wine"));
            Add(new GreekGod("Hephaestus", "God of fire and crafts"));
            Add(new GreekGod("Hera", "Goddess of marriage"));
            Add(new GreekHero("Hercules"));
            Add(new GreekGod("Hermes", "Messenger of the gods and guide of dead souls to the Underworld"));
            Add(new GreekHero("Jason"));
            Add(new GreekHero("Odysseus"));
            Add(new GreekHero("Perseus"));
            Add(new GreekGod("Poseidon", "God of the sea, earthquakes and horses"));
            Add(new GreekHero("Theseus"));
            Add(new GreekGod("Zeus", "The supreme god of the Olympians"));
        }
    }

    public class GreekGod
    {
        private string godName;

        public string GodName
        {
            get { return godName; }
            set { godName = value; }
        }

        private string godDescription;

        public string GodDescription
        {
            get { return godDescription; }
            set { godDescription = value; }
        }

        public GreekGod(string godName, string godDescription)
        {
            this.GodName = godName;
            this.GodDescription = godDescription;
        }
    }

    public class GreekHero
    {
        private string heroName;

        public string HeroName
        {
            get { return heroName; }
            set { heroName = value; }
        }

        public GreekHero(string heroName)
        {
            this.HeroName = heroName;
        }
    }

    public class Places : ObservableCollection<Place>
    {
        public Places()
        {
            Add(new Place("Bellevue", "WA"));
            Add(new Place("Bellingham", "WA"));
            Add(new Place("Kirkland", "WA"));
            Add(new Place("Los Angeles", "CA"));
            Add(new Place("Portland", "OR"));
            Add(new Place("Redmond", "WA"));
            Add(new Place("San Diego", "CA"));
            Add(new Place("San Francisco", "CA"));
            Add(new Place("San Jose", "CA"));
            Add(new Place("Santa Ana", "CA"));
            Add(new Place("Seattle", "WA"));
        }
    }

    public class Place
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public Place(string name, string state)
        {
            this.name = name;
            this.state = state;
        }
    }
}
