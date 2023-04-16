using System.Collections;
using System.Globalization;

namespace MauiShowcase.Pages.Collections.Converters
{
    internal class ArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join(parameter?.ToString() ?? ", ", ((IEnumerable)value).Cast<object>());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
