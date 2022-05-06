using System.Collections.Generic;
using System;

namespace OOP21_Calculator.Alni
{
    /// <summary>
    /// Static Factory that creates the maps with the Combinatorics Operations and puts them in a CalculatorModel.
    /// </summary>
    public class CombinatoricsCalculatorModelFactory
    {
        private CombinatoricsCalculatorModelFactory() { }

        /// <returns>a CalculatorModel that has two maps containing all the operators of this calculator</returns>
        public static ICalculatorModel Create()
        {
            Dictionary<string, CCBinaryOperator> binMap = new Dictionary<string, CCBinaryOperator>
            {
                { "factorial", CreateBinaryFunction((x, y) => FallingFactorial(x, y)) },
                { "binomialCoefficient", CreateBinaryFunction((a, b) => BinomialCoefficient(a, b)) },
                { "sequencesNumber", CreateBinaryFunction((n, m) => SequencesNumber(n, m)) },
                { "binaryFibonacci", CreateBinaryFunction((n, k) => BinaryFibonacci(n, k)) },
                { "stirlingNumber", CreateBinaryFunction((n, k) => StirlingNumber(n, k)) }
            };
            Dictionary<string, CCUnaryOperator> unMap = new Dictionary<string, CCUnaryOperator>
            {
                { "fibonacci", CreateUnaryFunction((n) => Fibonacci(n)) },
                { "derangement", CreateUnaryFunction((n) => Derangement(n)) },
                { "bellNumber", CreateUnaryFunction((n) => BellNumber(n)) }
            };
            return new CalculatorModelTemplate(binMap, unMap);
        }
        private static double FallingFactorial(double n, double m)
        {
            if (m > n)
            {
                return 0;
            }
            double result = 1;
            for (int i = 0; i < m; i++)
            {
                result *= n - i;
            }
            return result;
        }
        private static double BinomialCoefficient(double a, double b)
        {
            double b1 = b > (a / 2) ? a - b : b;
            return b1 < 0 ? 0 : FallingFactorial(a, b1) / FallingFactorial(b1, b1);
        }
        private static double SequencesNumber(double n, double m) => Math.Pow(n, m);
        private static double BinaryFibonacci(double n, double k) => BinomialCoefficient(n - k + 1, k);
        private static double Fibonacci(double n)
        {
            if (n < 1)
            {
                return 0;
            }
            double result = 0.0;
            if (n <= 3)
            {
                result++;
            }
            for (double k = 0; k < n - 2; k++)
            {
                result += BinaryFibonacci(n - 2, k);
            }
            return result;
        }
        private static double Derangement(double n)
        {
            double result = 0;
            for (int k = 0; k <= n; k++)
            {
                result += Math.Pow(-1, k) * FallingFactorial(n, n - k);
            }
            return result;
        }
        private static double BellNumber(double n)
        {
            if (n > BELL_NUMBER_MAX)
            {
                return Double.PositiveInfinity;
            }
            if (n == 0)
            {
                return 1;
            }
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                result += BinomialCoefficient(n - 1, i) * BellNumber(i);
            }
            return result;
        }
        private static double StirlingNumber(double n, double k)
        {
            if (k > n)
            {
                return 0;
            }
            double result = 0;
            for (double i = 0; i <= k; i++)
            {
                result += Math.Pow(-1, k - i) * Math.Pow(i, n) * BinomialCoefficient(k, i);
            }
            return result / FallingFactorial(k, k);
        }
        private static CCBinaryOperator CreateBinaryFunction(Func<double, double, double> op) => new CCBinaryOperator(op, 0, CCType.LEFT);
        private static CCUnaryOperator CreateUnaryFunction(Func<double, double> op) => new CCUnaryOperator(op, 0, CCType.LEFT);
        private static readonly double BELL_NUMBER_MAX = 30;
    }
}
