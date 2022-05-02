namespace OOP21_Calculator.Lepore
{
    public interface ICalculatorController
    {
        public double ApplyBinaryOperator(string op, double a, double b);

        public double ApplyUnaryOperator(string op, double a);

        public bool IsUnaryOperator(string op);

        public bool IsBinaryOperator(string op);

        public int GetPrecedence(string op);

        public CCType GetType(string op);
    }
}
