using System.Globalization;

namespace MauiShowcase.Pages.CustomView.Converters
{
    public class MultiDoubleToColorConverter : IMultiValueConverter
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
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }

            double multiplier = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);

            double ratio = (current.Value - minimum.Value) / (maximum.Value - minimum.Value);

            return new SolidColorBrush(Color.FromHsla(System.Convert.ToSingle(ratio * multiplier), 1.0, 0.4));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
