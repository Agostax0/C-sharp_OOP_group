using System.Collections.Generic;

namespace OOP21_Calculator.Alni
{
    public class Combinatoricsfactory
    {
        public static ICalculatorModel Create()
        {
            Dictionary<string, CCBinaryOperator> dic = new Dictionary<string, CCBinaryOperator>();
            Dictionary<string, CCUnaryOperator> dic2 = new Dictionary<string, CCUnaryOperator>();
            dic.Add("Somma", new CCBinaryOperator((x, y) => Sum(x, y), 0, null));
            dic2.Add("Precedente", new CCUnaryOperator((x) => x - 1, 0, null));
            return new CalculatorModelTemplate(dic, dic2);
        }
        static double Sum(double x, double y)
        {
            return x + y;
        }
    }
}
