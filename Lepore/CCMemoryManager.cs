using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    class CCMemoryManager : IMemoryManager
    {
        private readonly IList<string> buffer;
        private readonly IList<string> history;

        public CCMemoryManager()
        {
            buffer = new List<string>();
            history = new List<string>();
        }

        public IList<string> State { get => buffer; set { buffer.Clear(); ReadAll(value); } }

        public void Read(string s)
        {
            Logger.log("Reading", s);
            buffer.Add(s);
        }

        public void ReadAll(IList<string> list)
        {
            foreach(string s in list)
            {
                Read(s);
            }
        }

        public void Clear()
        {
            buffer.Clear();
        }
    }
}
