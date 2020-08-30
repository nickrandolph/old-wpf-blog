using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace MasterDetail
{
    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string strValue = value as string;
            if (strValue != null)
            {
                return new BitmapImage(new Uri($"ms-appx:///{strValue}", UriKind.RelativeOrAbsolute));
            }
            throw new InvalidOperationException("Unexpected value in converter");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new InvalidOperationException("The method or operation is not implemented.");
        }

    }
}
