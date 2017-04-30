using Challenge201704.XamarinKorea.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea.Converters
{
    /// <summary>
    /// 남성 여부 체크 Conver class
    /// </summary>
    public class IsMaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Gender gender)
            {
                return gender.Equals(Gender.Male);
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
