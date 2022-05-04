using System;
using System.Collections.Generic;
using System.Text;

namespace OOP21_Calculator.Lepore
{
    public interface IMemoryModel
    {
        IList<string> State { get; }
        IList<string> History { get; }

        void AddInput(string s);

        void ClearBuffer();

        void AddToHistory(string s);


    }
}
