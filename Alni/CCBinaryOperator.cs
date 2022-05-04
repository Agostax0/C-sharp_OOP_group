using System;

namespace OOP21_Calculator.Alni
{
    /// <summary>
    /// The generic operator for binary operations. It contains a Function with two parameters, a int for the precedence and a CCType for the type of association.
    /// </summary>
    public class CCBinaryOperator
    {
        private readonly Func<double, double, double> _op;
        public int Prec { get; }
        public CCType Op_Type { get; }

        public CCBinaryOperator(Func<double, double, double> op, int prec, CCType type)
        {
            Op_Type = type;
            Prec = prec;
            _op = op;
        }

        ///<summary>
        /// (<paramref name="a"/>, <paramref name="b"/>)
        ///</summary>
        /// <param name="a">first operand</param>
        /// <param name="b">first operand</param>
        /// <returns>the result of the binary operation</returns>
        public double apply(double a, double b) => _op.Invoke(a, b);
    }
}
