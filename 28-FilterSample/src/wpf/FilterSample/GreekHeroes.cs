using System.Collections.ObjectModel;


namespace FilterSample
{
    public class GreekHeroes : ObservableCollection<GreekHero>
	{
		public GreekHeroes()
		{
			this.Add(new GreekHero("Bellerophon"));
			this.Add(new GreekHero("Hercules"));
			this.Add(new GreekHero("Jason"));
			this.Add(new GreekHero("Odysseus"));
			this.Add(new GreekHero("Perseus"));
			this.Add(new GreekHero("Theseus"));
		}
	}
}