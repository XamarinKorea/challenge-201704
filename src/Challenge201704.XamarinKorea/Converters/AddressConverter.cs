using Challenge201704.XamarinKorea.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea.Converters
{
    /// <summary>
    /// 사용자 주소 변환 Converter Class
    /// </summary>
    public class AddressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Address address)
            {
                return $"{address.Street}, {address.City}, {address.State} {address.PostCode}";
            }
            else
            {
                throw new InvalidOperationException("The target must be a Address");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
