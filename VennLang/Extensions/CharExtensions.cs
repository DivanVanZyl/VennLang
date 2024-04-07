using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VennLang.Extensions
{
    public static class CharExtensions
    {
        public static bool IsNumber(this char c)
        {
            return Char.IsDigit(c) || c == '.';
        }
        public static bool IsLetter(this char c)
        {
            return Char.IsLetter(c);
        }
        public static bool IsWhitespace(this char c)
        {
            return Char.IsWhiteSpace(c);
        }
    }
}
