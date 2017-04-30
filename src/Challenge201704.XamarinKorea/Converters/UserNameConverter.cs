using Challenge201704.XamarinKorea.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea.Converters
{
    /// <summary>
    /// 사용자 이름 변환 Conver class
    /// </summary>
    public class UserNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is UserName name)
            {
                return $"{name.Title}. {name.First} {name.Last}";
            }
            else
            {
                throw new InvalidOperationException("The target must be a UserName");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
