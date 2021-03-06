using OOP21_Calculator.Alni;
using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Agosta
{
    static class StandardCalculatorModelFactory
    {
        ///<summary>This Class returns a CalculatorModelTemplate containing a dictionary of
        ///     the following standard operators:
        ///     - sum, sub, mult, div, root, square, inverse.
        ///</summary>
        //TODO <listheader> documentation
        public static ICalculatorModel Create()
        {
            Dictionary<string, CCBinaryOperator> binaryOperators = new Dictionary<string, CCBinaryOperator>();
            Dictionary<string, CCUnaryOperator> unaryOperators = new Dictionary<string, CCUnaryOperator>();
            binaryOperators.Add("sum", new CCBinaryOperator((x, y) => sum(x, y), 1, CCType.LEFT));
            binaryOperators.Add("sub", new CCBinaryOperator((x,y)=> sub(x,y), 1, CCType.LEFT));
            binaryOperators.Add("mult", new CCBinaryOperator((x,y)=> mult(x,y), 2, CCType.LEFT));
            binaryOperators.Add("div", new CCBinaryOperator((x, y) => div(x, y), 3, CCType.LEFT));

            unaryOperators.Add("root", new CCUnaryOperator((x) => root(x), 4, CCType.LEFT));
            unaryOperators.Add("inverse", new CCUnaryOperator((x) => inverse(x), 4, CCType.LEFT));
            unaryOperators.Add("square", new CCUnaryOperator((x) => square(x), 4, CCType.LEFT));
            return new CalculatorModelTemplate(binaryOperators, unaryOperators);
        }

        private static double sum(double n1, double n2) => n1 + n2;
        private static double sub(double n1, double n2) => n1 - n2;
        private static double mult(double n1, double n2) => n1 * n2;
        private static double div(double n1, double n2) => (n2 == 0) ? 
            (n1 > 0) ? double.PositiveInfinity : double.NegativeInfinity 
            : n1 / n2;

        private static double root(double n1) => (n1 < 0) ? double.NaN : Math.Sqrt(n1);

        private static double inverse(double n1) => (n1 == 0) ? double.PositiveInfinity : 1 / n1;

        private static double square(double n1) => n1 * n1;
    }
}
