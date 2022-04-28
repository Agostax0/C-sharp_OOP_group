using System;

namespace OOP21_Calculator.Alni
{
    public class CCUnaryOperator
    {
        int Prec { get; }
        Type Op_Type { get; }
        readonly Func<double, double> _op;

        public CCUnaryOperator(Func<double, double> op, int prec, Type type)
        {
            Op_Type = type;
            Prec = prec;
            _op = op;
        }
        public double apply(double a) => _op.Invoke(a);
    }
}
