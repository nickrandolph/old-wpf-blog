using System;
using System.Xml.Linq;
using Windows.UI.Xaml.Data;

namespace ChangePanelItemsControl
{
    public class XmlElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is XElement element)
            {
                return element.Element(XName.Get(parameter as string)).Value;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
