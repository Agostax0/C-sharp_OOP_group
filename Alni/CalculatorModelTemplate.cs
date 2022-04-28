using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    public class CalculatorModelTemplate : ICalculatorModel
    {
        private readonly Dictionary<string, CCBinaryOperator> _b_map;
        private readonly Dictionary<string, CCUnaryOperator> _u_map;

        public Dictionary<string, CCBinaryOperator> Get_Binary_Ops()
        {
            return _b_map;
        }
        public Dictionary<string, CCUnaryOperator> Get_Unary_Ops()
        {
            return _u_map;
        }
        public CalculatorModelTemplate(Dictionary<string, CCBinaryOperator> b_map, Dictionary<string, CCUnaryOperator> u_map)
        {
            _b_map = b_map;
            _u_map = u_map;
        }
    }
}
