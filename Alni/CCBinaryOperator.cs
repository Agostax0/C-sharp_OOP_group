using System;

namespace OOP21_Calculator.Alni
{
    public class CCBinaryOperator
    {
        int Prec { get; }
        Type Op_Type { get; }
        Func<double, double, double> _op;

        public CCBinaryOperator(Func<double, double, double> op, int prec, Type type)
        {
            Op_Type = type;
            Prec = prec;
            _op = op;
        }
        public double apply(double a, double b) => _op.Invoke(a, b);
    }
}
