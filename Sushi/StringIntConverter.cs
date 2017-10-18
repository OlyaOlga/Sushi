using System;
using System.Globalization;
using System.Windows.Data;

namespace Sushi
{
    class StringIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            uint res;
            bool intFromat = uint.TryParse(value?.ToString(), out res);
            if (intFromat)
            {
                return res;
            }
            return null;
        }
    }
}