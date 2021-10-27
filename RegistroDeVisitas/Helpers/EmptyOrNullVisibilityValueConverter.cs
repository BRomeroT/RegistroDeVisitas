using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RegistroDeVisitas.Helpers
{
    internal class EmptyOrNullBoolValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            var content = value.ToString();
            if (string.IsNullOrWhiteSpace(content)) return false;
            return int.TryParse(content, out int intValue) && intValue == 0 ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
