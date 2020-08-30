using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;


namespace MasterDetail
{
    public class StringToImageSourceConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strValue = value as string;
            if (strValue != null)
            {
                return new BitmapImage(new Uri(strValue, UriKind.Relative));
            }
            throw new InvalidOperationException("Unexpected value in converter");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new InvalidOperationException("The method or operation is not implemented.");
        }
    }
}