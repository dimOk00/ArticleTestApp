using System;
using Windows.UI.Xaml.Data;

namespace ArticleTestApp.Converters
{
    public class DateTimeOffsetToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime targetTime  = (DateTime)value;
            return targetTime.ToString("dd.MM.yyyy");
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.Parse(value.ToString());
        }
    }
}
