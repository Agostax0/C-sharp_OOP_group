using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    public interface ICalculatorModel
    {
        public Dictionary<string, CCBinaryOperator> Get_Binary_Ops();
        public Dictionary<string, CCUnaryOperator> Get_Unary_Ops();
    }
}

