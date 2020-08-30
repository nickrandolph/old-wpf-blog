using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;
using System;


namespace MasterDetail.Desktop
{
    public class StringToImageSourceConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string strValue = value as string;
            if (strValue != null)
            {
                return new BitmapImage(new Uri(@$"ms-appx:///{strValue}", UriKind.RelativeOrAbsolute));
            }
            throw new InvalidOperationException("Unexpected value in converter");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}