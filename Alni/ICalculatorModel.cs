using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    public interface ICalculatorModel
    {
        public Dictionary<string, CCBinaryOperator> BinaryOps { get; }

        public Dictionary<string, CCUnaryOperator> UnaryOps { get; }
    }
}

