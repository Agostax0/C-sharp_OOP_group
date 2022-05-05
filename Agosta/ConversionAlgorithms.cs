using System;
using System.Linq;

namespace OOP21_Calculator.Agosta
{
    static class ConversionAlgorithms
    {
        ///<summary> Converts the value to the specified base.
        ///
        /// <param name="value">the value to be converted.</param>
        /// <param name="convBase">the base to convert the value.</param>
        /// </summary>
        /// <remarks> the converted value is represented using the "+" or "-" followed by the absolute value.</remarks>
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
        /// <summary> Converts the value to the decimal base.  
        /// (<paramref name="value"/>,<paramref name="convBase"/>)
        /// </summary>
        /// <param name="value">the value to be converted.</param>
        /// <param name="convBase">the conversion base of the value.</param>
        public static long ToUnsignedDecimal(string value, int convBase)
        {
            long ret = 0;
            for(int i = 1; i < value.Length; i++)
            {
                ret += (long)(hexadecimalLetters(char.ToString(value.ElementAt(i))) * Math.Pow(convBase, value.Length - 1 - i));
            }
            return ret;
        }
        ///<summary> Converts the value to the decimal base.  
        /// (<paramref name="value"/>,<paramref name="convBase"/>)
        ///</summary>
        /// <param name="value">the value to be converted.</param>
        /// <param name="convBase">the conversion base of the value.</param>
        /// <remarks> This method doesn't care of the value's sign. </remarks>
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
