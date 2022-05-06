using OOP21_Calculator.Alni;
using OOP21_Calculator.Agosta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP21_Calculator.Tassinari
{
    public class ScientificCalculatorModelFactory
    {
        private ScientificCalculatorModelFactory() { }
        public static ICalculatorModel Create()
        {
            Dictionary<string, CCBinaryOperator> binaryOperators = new Dictionary<string, CCBinaryOperator>();
            binaryOperators.Add("root", new CCBinaryOperator((y, x) => Math.Pow(y, 1 / x), 6, CCType.RIGHT));
            binaryOperators.Add("^", new CCBinaryOperator((x, y) => Math.Pow(x, y), 5, CCType.RIGHT));

            Dictionary<string, CCUnaryOperator> unaryOperators = new Dictionary<string, CCUnaryOperator>();
            unaryOperators.Add("log", new CCUnaryOperator((x) => Math.Log10(x), 1, CCType.LEFT));
            unaryOperators.Add("ln", new CCUnaryOperator((x) => Math.Log(x), 1, CCType.LEFT));
            unaryOperators.Add("abs", new CCUnaryOperator((x) => Math.Abs(x), 1, CCType.LEFT));
            unaryOperators.Add("factorial", new CCUnaryOperator((x) => (double) LongStream.rangeClosed(1, Math.Round(x)).reduce(1, (long x1, long x2) => x1 * x2), 1, null));
            unaryOperators.Add("sin", new CCUnaryOperator((x) => Math.Sin(x), 1, CCType.LEFT));
            unaryOperators.Add("cos", new CCUnaryOperator((x) => Math.Cos(x), 1, CCType.LEFT));
            unaryOperators.Add("tan", new CCUnaryOperator((x) => Math.Tan(x), 1, CCType.LEFT));
            unaryOperators.Add("csc", new CCUnaryOperator((x) => 1 / Math.Sin(x), 1, CCType.LEFT));
            unaryOperators.Add("sec", new CCUnaryOperator((x) => 1 / Math.Cos(x), 1, CCType.LEFT));
            unaryOperators.Add("cot", new CCUnaryOperator((x) => Math.Cos(x) / Math.Sin(x), 1, CCType.LEFT));
            

            return new CalculatorModelTemplate(binaryOperators, unaryOperators);
        }
    }
}
