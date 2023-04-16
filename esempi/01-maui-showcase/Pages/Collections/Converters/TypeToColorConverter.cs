using Microsoft.Maui.Graphics.Converters;
using System.Globalization;

namespace MauiShowcase.Pages.Collections.Converters
{
    internal class TypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            string colorName = value?.ToString() switch
            {
                "water" => "Blue",
                "fire" => "Red",
                "grass" => "Green",
                "ground" => "DarkGoldenrod",
                "rock" => "Brown",
                "steel" => "SlateGray",
                "ice" => "CadetBlue",
                "electric" => "Orange",
                "dragon" => "DarkSeaGreen",
                "ghost" => "Purple",
                "psychic" => "MediumVioletRed",
                "normal" => "Gray",
                "fighting" => "DarkRed",
                "poison" => "BlueViolet",
                "bug" => "DarkOliveGreen",
                "flying" => "CornflowerBlue",
                "dark" => "DarkSlateGray",
                "fairy" => "DeepPink",
                _ => "Black"
            };

            return new SolidColorBrush((Color)converter.ConvertFromString(colorName));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
