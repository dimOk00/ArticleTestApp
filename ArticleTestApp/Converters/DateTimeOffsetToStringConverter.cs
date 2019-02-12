using System;
using Windows.UI.Xaml.Data;

namespace ArticleTestApp.Converters
{
    public class DateTimeOffsetToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is DateTime targetTime ? targetTime.ToString("dd.MM.yyyy") : null;
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            try
            {
                return DateTime.Parse(value.ToString());
            }
            catch(FormatException)
            {
                return null;
            }
        }
    }
}
