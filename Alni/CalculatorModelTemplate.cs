using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    public class CalculatorModelTemplate : ICalculatorModel
    {
        public Dictionary<string, CCBinaryOperator> BinaryOps { get; }
        public Dictionary<string, CCUnaryOperator> UnaryOps { get; }

        public CalculatorModelTemplate(Dictionary<string, CCBinaryOperator> binMap, Dictionary<string, CCUnaryOperator> unMap)
        {
            BinaryOps = binMap;
            UnaryOps = unMap; ;
        }
    }
}
