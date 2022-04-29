using OOP21_Calculator.Alni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agosta
{
    static class ProgrammerCalculatorModelFactory
    {
        public static ICalculatorModel Create()
        {
            Dictionary<string, CCBinaryOperator> binaryOperators = new Dictionary<string, CCBinaryOperator>();
            Dictionary<string, CCUnaryOperator> unaryOperators = new Dictionary<string, CCUnaryOperator>();
            binaryOperators.Add("and", new CCBinaryOperator((x, y) => And(x, y), 3, null));
            binaryOperators.Add("or", new CCBinaryOperator((x, y) => Or(x, y), 3, null));
            binaryOperators.Add("xor", new CCBinaryOperator((x, y) => Xor(x, y), 3, null));
            binaryOperators.Add("nand", new CCBinaryOperator((x, y) => Nand(x, y), 3, null));
            binaryOperators.Add("nor", new CCBinaryOperator((x, y) => Nor(x, y), 3, null));
            binaryOperators.Add("shiftL", new CCBinaryOperator((x, y) => ShiftL(x, y), 3, null));
            binaryOperators.Add("shiftR", new CCBinaryOperator((x, y) => ShiftR(x, y), 3, null));
            binaryOperators.Add("roR", new CCBinaryOperator((x, y) => RoR(x, y), 3, null));
            binaryOperators.Add("roL", new CCBinaryOperator((x, y) => RoL(x, y), 3, null));

            unaryOperators.Add("not", new CCUnaryOperator((x) => Not(x), 4, null));
            return new CalculatorModelTemplate(binaryOperators,unaryOperators);
        }

        private static double And(double n1, double n2) => (long)n1 & (long)n2;

        private static double Or(double n1, double n2) => (long)n1 | (long)n2;

        private static double Nand(double n1, double n2) => Not(And(n1, n2));

        private static double Nor(double n1, double n2) => Not(Or(n1, n2));

        private static double Xor(double n1, double n2) => (long)n1 ^ (long)n2;

        private static double ShiftR(double n1, double n2) => (long)n1 >> (int)n2;

        private static double ShiftL(double n1, double n2) => (long)n1 << (int)n2;

        private static string AddLeadingZerosToByte(string str)
        {
            string unsigned = str.Substring(1);
            while(unsigned.Length % 8 != 0)
            {
                unsigned = "0" + unsigned;
            }
            return char.ToString(str.ElementAt(0)) + unsigned;
        }

        private static double Not(double n1)
        {
            string conv = ConversionAlgorithms.ToBase((long)n1, 2);
            string addedZero = AddLeadingZerosToByte(conv);
            string sign = Char.ToString(addedZero.ElementAt(0));
            var iter = addedZero.Substring(1).GetEnumerator();
            string ret = "";
            while (iter.MoveNext())
            {
                ret += ("0".Equals(char.ToString(iter.Current))) ? "1" : "0";
            }
            return ConversionAlgorithms.ToSignedDecimal(sign + ret, 2);
        }

        private static double RoR(double n1, double n2)
        {
            string conv = ConversionAlgorithms.ToBase((long)n1, 2);
            string addedZero = AddLeadingZerosToByte(conv);
            string sign = Char.ToString(conv.ElementAt(0));
            string ret = addedZero.Substring(1);
            ret = ret.Substring(ret.Length - (int)n2) + ret.Substring(0, ret.Length - (int)n2);
            return ConversionAlgorithms.ToSignedDecimal(sign + ret, 2);
        }
        private static double RoL(double n1, double n2)
        {
            string conv = ConversionAlgorithms.ToBase((long)n1, 2);
            string addedZero = AddLeadingZerosToByte(conv);
            string sign = Char.ToString(conv.ElementAt(0));
            string ret = addedZero.Substring(1);
            ret = ret.Substring((int)n2) + ret.Substring(0, (int)n2);
            return ConversionAlgorithms.ToSignedDecimal(sign + ret, 2);
        }

    }
}
