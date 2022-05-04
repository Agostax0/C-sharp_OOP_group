using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;
using static OOP21_Calculator.Lepore.CCType;

namespace OOP21_Calculator.Lepore {

    /// <summary>
    /// Class used to simulate the interaction with the standard calculator controller.
    /// This class wasn't implemented by me in the original project.
    /// </summary>
    class StandardController : ICalculatorController
    {
        private readonly IDictionary<string, (Func<double, double, double>, int, CCType)> _binaryOperators = new Dictionary<string, (Func<double, double, double>, int, CCType)>()
        {
            {"+", ((a,b) => a+b, 1, LEFT )},
            {"-", ((a,b) => a-b, 1, LEFT )},
            {"*", ((a,b) => a*b, 2, LEFT )},
            {"/", ((a,b) => a/b, 2, LEFT )},
            {"^", ((a,b) => Math.Pow(a,b), 3, RIGHT )},
        };
        private readonly IDictionary<string, (Func<double, double>, int, CCType)> _unaryOperators = new Dictionary<string, (Func<double, double>, int, CCType)>()
        {
            {"sqrt", ((a) => Math.Sqrt(a), 4, LEFT )},
        };
        public double ApplyBinaryOperator(string op, double a, double b)
        {
            _binaryOperators.TryGetValue(op, out var val);
            return val.Item1.Invoke(a, b);
        }

        public double ApplyUnaryOperator(string op, double a)
        {
            _unaryOperators.TryGetValue(op, out var val);
            return val.Item1.Invoke(a);
        }

        public bool IsUnaryOperator(string op)
        {
            return _unaryOperators.TryGetValue(op, out var val);
        }

        public bool IsBinaryOperator(string op)
        {
            return _binaryOperators.TryGetValue(op, out var val);
        }

        public int GetPrecedence(string op)
        {
            _binaryOperators.TryGetValue(op, out var val);
            return val.Item2;
        }

        public CCType GetType(string op)
        {
            _binaryOperators.TryGetValue(op, out var val);
            return val.Item3;
        }
    }
}
