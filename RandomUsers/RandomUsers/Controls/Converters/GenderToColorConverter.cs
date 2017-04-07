using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomUsers.Controls.Converters
{
    public class GenderToColorConverter : BindableObject, IValueConverter
    {
        public static readonly BindableProperty MaleColorProperty = BindableProperty.Create(nameof(MaleColor), typeof(Color), typeof(GenderToColorConverter), Color.Accent);

        public Color MaleColor
        {
            get { return (Color)GetValue(MaleColorProperty); }
            set { SetValue(MaleColorProperty, value); }
        }

        public static readonly BindableProperty FemaleColorProperty = BindableProperty.Create(nameof(FemaleColor), typeof(Color), typeof(GenderToColorConverter), Color.Accent);

        public Color FemaleColor
        {
            get { return (Color)GetValue(FemaleColorProperty); }
            set { SetValue(FemaleColorProperty, value); }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = (string)value;
            if(strValue.ToLower() == "male")
            {
                return MaleColor;
            }
            else
            {
                return FemaleColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
