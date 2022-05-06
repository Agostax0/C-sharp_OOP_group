using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    public interface IEngine
    {
        double Calculate(IList<string> input);

        IList<string> ParseToRPN(IList<string> infix);
    }
}
