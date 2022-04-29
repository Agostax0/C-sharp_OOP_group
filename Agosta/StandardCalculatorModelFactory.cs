using OOP21_Calculator.Alni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agosta
{
    static class StandardCalculatorModelFactory
    {
        public static ICalculatorModel Create()
        {
            Dictionary<string, CCBinaryOperator> binaryOperators = new Dictionary<string, CCBinaryOperator>();
            Dictionary<string, CCUnaryOperator> unaryOperators = new Dictionary<string, CCUnaryOperator>();
            binaryOperators.Add("sum", new CCBinaryOperator((x, y) => sum(x, y), 1, null));
            binaryOperators.Add("sub", new CCBinaryOperator((x,y)=> sub(x,y), 1, null));
            binaryOperators.Add("mult", new CCBinaryOperator((x,y)=> mult(x,y), 2, null));
            binaryOperators.Add("div", new CCBinaryOperator((x, y) => div(x, y), 3, null));

            unaryOperators.Add("root", new CCUnaryOperator((x) => root(x), 4, null));
            unaryOperators.Add("inverse", new CCUnaryOperator((x) => inverse(x), 4, null));
            unaryOperators.Add("square", new CCUnaryOperator((x) => square(x), 4, null));
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
