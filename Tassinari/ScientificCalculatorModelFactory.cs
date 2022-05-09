using OOP21_Calculator.Alni;
using OOP21_Calculator.Agosta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP21_Calculator.Tassinari
{
    public class ScientificCalculatorModelFactory
    {
        ///<summary>This Class returns a CalculatorModelTemplate containing a dictionary of
        ///     the following operators:
        ///     - root, ^, log, ln, abs, factorial, sin, cos, tan, csc, sec, cot.
        ///     + all the operators from StandardCalculatorModelFactory
        ///</summary>
        private ScientificCalculatorModelFactory() { }
        public static ICalculatorModel Create()
        {
            Dictionary<string, CCBinaryOperator> binaryOperators = new Dictionary<string, CCBinaryOperator>();
            binaryOperators.Add("root", new CCBinaryOperator((y, x) => Math.Pow(y, 1 / x), 6, CCType.RIGHT));
            binaryOperators.Add("^", new CCBinaryOperator((x, y) => Math.Pow(x, y), 5, CCType.RIGHT));
            binaryOperators = binaryOperators.Concat(StandardCalculatorModelFactory.Create().BinaryOps).ToDictionary(e => e.Key, e => e.Value);

            Dictionary<string, CCUnaryOperator> unaryOperators = new Dictionary<string, CCUnaryOperator>();
            unaryOperators.Add("log", new CCUnaryOperator((x) => Math.Log10(x), 1, CCType.LEFT));
            unaryOperators.Add("ln", new CCUnaryOperator((x) => Math.Log(x), 1, CCType.LEFT));
            unaryOperators.Add("abs", new CCUnaryOperator((x) => Math.Abs(x), 1, CCType.LEFT));
            unaryOperators.Add("factorial", new CCUnaryOperator((x) => Fact((int) Math.Round(x)), 1, CCType.LEFT));
            unaryOperators.Add("sin", new CCUnaryOperator((x) => Math.Sin(x), 1, CCType.LEFT));
            unaryOperators.Add("cos", new CCUnaryOperator((x) => Math.Cos(x), 1, CCType.LEFT));
            unaryOperators.Add("tan", new CCUnaryOperator((x) => Math.Tan(x), 1, CCType.LEFT));
            unaryOperators.Add("csc", new CCUnaryOperator((x) => 1 / Math.Sin(x), 1, CCType.LEFT));
            unaryOperators.Add("sec", new CCUnaryOperator((x) => 1 / Math.Cos(x), 1, CCType.LEFT));
            unaryOperators.Add("cot", new CCUnaryOperator((x) => Math.Cos(x) / Math.Sin(x), 1, CCType.LEFT));
            unaryOperators = unaryOperators.Concat(StandardCalculatorModelFactory.Create().UnaryOps).ToDictionary(e => e.Key, e => e.Value);

            return new CalculatorModelTemplate(binaryOperators, unaryOperators);
        }

        private static double Fact(int x)
        {
            if (x > 0)
            {
                double result = x;
                for (int i = x - 1; i > 0; i--)
                {
                    result *= i;
                }
                return result;
            }
            return 1;
        }
    }
}
