using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace GroupByType
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

			var godsAndHeros = new GreekGodsAndHeroes();
			var selector = new GroupByTypeConverter();
			var groups = (from gh in godsAndHeros
																 let grouping = selector.Convert(gh, typeof(string), null, null) as string
																 group gh by grouping).ToArray();
            (Resources["cvs"] as CollectionViewSource).Source = groups;
		}
    }

    public class GodHeroTemplateSelector : DataTemplateSelector
	{
        public DataTemplate GreekGroup { get; set; }
		public DataTemplate GreekGod { get; set; }
		public DataTemplate GreekHero { get; set; }
		protected override DataTemplate SelectTemplateCore(object item)
		{
			if (item is IGrouping<object, object>)
			{
				return GreekGroup;
			}
			else if (item is GreekGod)
			{
				return GreekGod;
			}
			else if (item is GreekHero)
			{
				return GreekHero;
			}
			else
			{
				return null;
			}
		}
	}

	public class GroupByTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is GreekGod)
			{
				return "Greek Gods";
			}
			else if (value is GreekHero)
			{
				return "Greek Heroes";
			}
			return null;
		}

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

	public class GreekGodsAndHeroes : ObservableCollection<object>
	{
		public GreekGodsAndHeroes()
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
}
