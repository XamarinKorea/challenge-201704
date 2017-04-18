using Challenge201704.XamarinKorea.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea.Converters
{
    /// <summary>
    /// 여성 여부 체크 Converter Class
    /// </summary>
    public class IsFemaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Gender gender)
            {
                return gender.Equals(Gender.Female);
            }
            else
            {
                throw new InvalidOperationException("The target must be a Gender");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
