using System;

namespace OOP21_Calculator.Alni
{
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
        public double apply(double a, double b) => _op.Invoke(a, b);
    }
}
