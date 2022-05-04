using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    /// <summary>
    /// Interface for the model of all the calculators. It contains all the operations(Unary/Binary)that this Calculator can do.
    /// </summary>
    public interface ICalculatorModel
    {
        public Dictionary<string, CCBinaryOperator> BinaryOps { get; }

        public Dictionary<string, CCUnaryOperator> UnaryOps { get; }
    }
}

