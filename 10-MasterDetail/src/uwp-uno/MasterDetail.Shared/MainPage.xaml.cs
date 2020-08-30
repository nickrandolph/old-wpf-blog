using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;


namespace MasterDetail
{
    public sealed partial class MainPage : Page
    {
        private XmlWrapper selectedItem;

        public XmlWrapper SelectedItem { get => selectedItem; 
            set { selectedItem = value; content.Content = value; } }

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            var stream = await GetEmbeddedFileStreamAsync(GetType(), "SolarSystemPlanetsData.xml");

            XDocument xdoc = XDocument.Load(stream);
            XmlNamespaceManager xnm = new XmlNamespaceManager(new NameTable());
            xnm.AddNamespace(String.Empty, "");
            var path = xdoc.XPathSelectElements("/SolarSystemPlanets/Planet", xnm).Select(x => new XmlWrapper(x)).ToArray();

#if WINDOWS_UWP
            (Resources["cvs"] as CollectionViewSource).Source = path;
#else
            listbox.ItemsSource = path;
#endif
            Console.WriteLine(path);
        }


        public static async Task<Stream> GetEmbeddedFileStreamAsync(Type assemblyType, string fileName)
        {
            await Task.Yield();

            var manifestName = assemblyType.GetTypeInfo().Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(n => n.EndsWith(fileName.Replace(" ", "_"), StringComparison.OrdinalIgnoreCase));

            if (manifestName == null)
            {
                throw new InvalidOperationException($"Failed to find resource [{fileName}]");
            }

            return assemblyType.GetTypeInfo().Assembly.GetManifestResourceStream(manifestName);
        }
    }

    public class XmlWrapper
    {
        private XObject XItem { get; }
        public XmlWrapper(XObject item)
        {
            XItem = item;
        }

        public string Value
        {
            get
            {
                return (XItem is XElement xelement) ? xelement.Value : (XItem as XAttribute)?.Value;
            }
        }

        public XmlWrapper this[string path]
        {
            get
            {
                if (XItem is XElement xelement)
                {
                    var name = XName.Get(path.Replace("@", ""));
                    if (path?.StartsWith("@") ?? false)
                    {
                        return new XmlWrapper(xelement.Attribute(name));
                    }
                    else
                    {
                        return new XmlWrapper(xelement.Element(name));
                    }
                }
                return null;
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
