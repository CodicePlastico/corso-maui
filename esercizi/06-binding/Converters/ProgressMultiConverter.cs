using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioBinding.Converters
{
    public class ProgressMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // minimo: -20
            // massimo: 60
            // valore: 0

            double value = (double)values[0];
            double minimum = (double)values[1];
            double maximum = (double)values[2];

            if (minimum > maximum)
            {
                throw new ArgumentException($"Il minimo {minimum} è superiore del massimo {maximum}");
                // return BindableProperty.UnsetValue;
            }

            // RESTITUIRE: 0.25

            double result = (value - minimum) / (maximum - minimum);
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
