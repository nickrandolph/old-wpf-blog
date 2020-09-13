using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace FilterSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
	{

		public Window1()
		{
			InitializeComponent();

			object src1 = this.Resources["src1"];
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(src1);
			collectionView.Filter = new Predicate<object>(FilterOutA);
		}

		public bool FilterOutA(object item)
		{
			GreekGod gg = item as GreekGod;
			if ((gg == null) || gg.RomanName.StartsWith("A"))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		private void FilterOutB(object sender, FilterEventArgs e)
		{
			GreekHero gh = e.Item as GreekHero;
			if ((gh == null) || gh.HeroName.StartsWith("B"))
			{
				e.Accepted = false;
			}
			else
			{
				e.Accepted = true;
			}
		}
	}
}