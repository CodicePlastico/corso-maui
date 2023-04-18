using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioImpaginazione.Content_Views.Converters
{
    public class PercToProgressConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(v => v is null))
            {
                return 0d;
            }

            double currentValue = System.Convert.ToDouble(values[0]);
            double maxValue = 100;
            double maxProgress = (double)values[1];

            // currentValue : maxValue = x : maxProgress
            // (currentValue * maxProgress) / maxValue;

            return currentValue * maxProgress / maxValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
