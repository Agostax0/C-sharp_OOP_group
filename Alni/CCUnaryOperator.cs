using System;

namespace OOP21_Calculator.Alni
{
    public class CCUnaryOperator
    {
        private readonly Func<double, double> _op;
        private int Prec { get; }
        private CCType Op_Type { get; }

        public CCUnaryOperator(Func<double, double> op, int prec, CCType type)
        {
            Op_Type = type;
            Prec = prec;
            _op = op;
        }
        public double apply(double a) => _op.Invoke(a);
    }
}
