using System;

namespace OOP21_Calculator.Alni
{
    /// <summary>
    /// The generic operator for unary operations. It contains a Function with one parameter, a int for the precedence and a CCType for the type of association.
    /// </summary>
    public class CCUnaryOperator
    {
        private readonly Func<double, double> _op;
        public int Prec { get; }
        public CCType Op_Type { get; }

        public CCUnaryOperator(Func<double, double> op, int prec, CCType type)
        {
            Op_Type = type;
            Prec = prec;
            _op = op;
        }

        ///<summary>
        /// (<paramref name="a"/>)
        ///</summary>
        /// <param name="a">first operand</param>
        /// <returns>the result of the unary operation</returns>
        public double apply(double a) => _op.Invoke(a);
    }
}
