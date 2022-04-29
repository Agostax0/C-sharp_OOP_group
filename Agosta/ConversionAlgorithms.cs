using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agosta
{
    static class ConversionAlgorithms
    {

        public static string ToBase(long value, int convBase)
        {
            if (convBase == 16)
            {
                return ToHex(value);
            }
            long abs = Math.Abs(value);
            string sign = (value >= 0) ? "+" : "-";
            return sign + Convert.ToString(abs, convBase);
        }

        private static string ToHex(long value)
        {
            long abs = Math.Abs(value);
            string sign = (value >= 0) ? "+" : "-";
            return sign + Convert.ToString(abs, 16).ToUpper();
        }
        private static long hexadecimalLetters(string bit)
        {
            switch (bit)
            {
                case "A":
                    return 10;
                case "B":
                    return 11;
                case "C":
                    return 12;
                case "D":
                    return 13;
                case "E":
                    return 14;
                case "F":
                    return 15;
                default:
                    return Convert.ToInt64(bit);
            }
        }
        public static long ToUnsignedDecimal(string value, int convBase)
        {
            long ret = 0;
            for(int i = 1; i < value.Length; i++)
            {
                ret += (long)(hexadecimalLetters(char.ToString(value.ElementAt(i))) * Math.Pow(convBase, value.Length - 1 - i));
            }
            return ret;
        }
        public static long ToSignedDecimal(string value, int convBase)
        {
            long ret = 0;
            for (int i = 1; i < value.Length; i++)
            {
                ret += (long)(hexadecimalLetters(char.ToString(value.ElementAt(i))) * Math.Pow(convBase, value.Length - 1 - i));
            }
            return (value.ElementAt(0).Equals('+')) ? ret : ret * -1;
        }
    }
}
