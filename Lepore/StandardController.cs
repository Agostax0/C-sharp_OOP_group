using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;
using static OOP21_Calculator.Lepore.CCType;

namespace OOP21_Calculator.Lepore {


    class StandardController
    {
        private readonly IDictionary<string, (int, CCType)> binaryOperators = new Dictionary<string, (int, CCType)>()
        {
            {"+", (1, LEFT) },
            {"-", (1, LEFT) },
            {"*", (2, LEFT) },
            {"/", (2, LEFT) },
            {"^", (3, RIGHT) },
        };
        private readonly IDictionary<string, (int, CCType)> unaryOperators = new Dictionary<string, (int, CCType)>()
        {
            {"sqrt", (4, RIGHT) },
        };
        public double ApplyBinaryOperator(string op, double a, double b)
        {
            switch (op)
            {
                case "+":
                    {
                        return a + b;
                    }
                case "-":
                    {
                        return a - b;
                    }
                case "*":
                    {
                        return a * b;
                    }
                case "/":
                    {
                        return a / b;
                    }
                case "^":
                    {
                        return Math.Pow(a, b);
                    }
                default: return 0;
            }
        }

        public double ApplyUnaryOperator(string op, double a)
        {
            switch (op)
            {
                case "sqrt":
                    {
                        return Math.Sqrt(a);
                    }
                default: return 0;
            }
        }

        public bool IsUnaryOperator(string op)
        {
            (int, CCType) val;
            return unaryOperators.TryGetValue(op, out val);
        }

        public bool IsBinaryOperator(string op)
        {
            (int, CCType) val;
            return binaryOperators.TryGetValue(op, out val);
        }

        public int GetPrecedence(string op)
        {
            (int, CCType) val;
            binaryOperators.TryGetValue(op, out val);
            return val.Item1;
        }

        public CCType GetType(string op)
        {
            (int, CCType) val;
            binaryOperators.TryGetValue(op, out val);
            return val.Item2;
        }
    }
}
