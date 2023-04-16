using System.Globalization;

namespace MauiShowcase.Pages.CustomView.Converters
{
    public class MultiDoubleToStrokeDashArrayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // values are: value, minimum, maximum
            // parameter is: multiplier
            double? current = (double?)values[0];
            double? minimum = (double?)values[1];
            double? maximum = (double?)values[2];
            if (current is null || minimum is null || maximum is null)
            {
                return new DoubleCollection(new[] { 0d, 0d });
            }

            double multiplier = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);

            double ratio = (current.Value - minimum.Value) / (maximum.Value - minimum.Value);

            return new DoubleCollection(new[] { ratio * multiplier, multiplier });
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
