using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    interface IEngine
    {
        double Calculate(IList<string> input);

        IList<string> ParseToRPN(IList<string> infix);
    }
}
