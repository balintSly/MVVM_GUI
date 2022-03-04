using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVM_GUI.Converters
{
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double num=double.Parse(value.ToString());
            if (num<4)
            {
                return Brushes.Red;
            }
            else if (num < 8)
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
