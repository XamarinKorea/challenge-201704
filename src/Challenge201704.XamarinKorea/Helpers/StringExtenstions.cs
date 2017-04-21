using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge201704.XamarinKorea.Helpers
{
    public static class StringExtenstions
    {
        public static string OnlyDigitNumber(this string value)
        {
            return new string(value.ToCharArray().Where(char.IsDigit).ToArray());
        }
    }
}
