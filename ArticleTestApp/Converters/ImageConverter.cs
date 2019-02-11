using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace ArticleTestApp.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new BitmapImage((Uri)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var img = (BitmapImage) value;
            return img.UriSource;
        }
    }
}
