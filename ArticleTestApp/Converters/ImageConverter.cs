using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace ArticleTestApp.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var bitmapImg = value as Uri;
            return bitmapImg != null ? new BitmapImage(bitmapImg) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var img = value as BitmapImage;
            return img?.UriSource;
        }
    }
}
