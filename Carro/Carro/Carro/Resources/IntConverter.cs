using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carro.Resources
{

    public class IntConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "0";
            int theint = (int)value;
            return theint.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
                strValue = "0";
            int resultint;
            if (int.TryParse(strValue, out resultint))
            {
                return resultint;
            }
            return 0;
        }

    }
}

