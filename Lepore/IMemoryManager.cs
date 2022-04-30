using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    interface IMemoryManager
    {
        IList<string> State { get; set; }

        void Read(string s);
        void ReadAll(IList<string> list);

        void Clear();
    }
}
