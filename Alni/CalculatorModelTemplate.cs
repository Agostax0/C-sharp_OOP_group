using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    /// <summary>
    /// Implementation of the calculators Model. It contains two HashMaps: one with the binary operations of this calculator and one with the unary ones.
    /// </summary>
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
