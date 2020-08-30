using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasterDetail.Desktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            Activated += MainWindow_Activated;   
        }

        private async void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {

            var stream = await GetEmbeddedFileStreamAsync(GetType(), "SolarSystemPlanetsData.xml");

            XDocument xdoc = XDocument.Load(stream);
            XmlNamespaceManager xnm = new XmlNamespaceManager(new NameTable());
            xnm.AddNamespace(String.Empty, "");
            var path = xdoc.XPathSelectElements("/SolarSystemPlanets/Planet", xnm).Select(x => new XmlWrapper(x)).ToArray();

            ((this.Content as Grid).Resources["cvs"] as CollectionViewSource).Source = path;
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
