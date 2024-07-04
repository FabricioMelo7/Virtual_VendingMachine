using System.Globalization;
using System.Windows.Data;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Converters
{
    public class ProductShapeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case ProductShape.Square:
                    return "M 14 11 Q 14.5 101 15 191 V 192 L 285 194 V 11 H 13.875";

                case ProductShape.Circle:
                    return "M 50,50 m -40,0 a 40,40 0 1,0 80,0 a 40,40 0 1,0 -80,0";

                case ProductShape.RoundedSquare:
                    return "M 23.738 8.511 H 77.749 Q 96.829 8.217 96.829 33.168 V 68.392 Q 97.709 94.81 77.749 93.93 H 25.793 Q 4.365 94.517 4.952 68.686 V 30.526 Q 4.365 7.337 22.857 8.511";

                case ProductShape.Hexagon:
                    return "M -5 45 L -23 56 L -23 74 L -5 85 L 13 74 L 13 56 Z";

                case ProductShape.SquareRoundTop:
                    return "M 40.77 8.036 H 63.028 Q 96.829 8.217 95.878 51.467 V 95.594 H 6.486 V 48.687 Q 4.365 7.337 40.677 8.036";

                case ProductShape.SquareRoundBottom:
                    return "M 4.927 8.006 H 95.784 V 58.972 Q 97.709 94.81 72.074 93.987 H 30.809 Q 4.365 94.517 5.014 59.044 V 8.05";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
