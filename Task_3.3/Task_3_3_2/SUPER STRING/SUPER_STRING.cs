using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_2
{
    public static class SUPER_STRING
    {
        public static string CheckString(this string str)
        {
            str = string.Join("", str.Where(i => Char.IsLetterOrDigit(i)));

            if (str == string.Empty)
            {
                throw new ArgumentException("String is empty");
            }
            if (str.All(i => Char.IsNumber(i)))
            {
                return "Numbers";
            }
            if (str.All(i => Char.IsLetter(i) && i < 1000))
            {
                return "English";
            }
            if (str.All(i => Char.IsLetter(i) && i > 1000))
            {
                return "Russian";
            }
            return "Mixed";
        }
    }
}
