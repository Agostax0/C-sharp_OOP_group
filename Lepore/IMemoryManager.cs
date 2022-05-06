using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    public interface IMemoryManager
    {
        IList<string> State { get; set; }
        IList<string> History { get; }

        void Read(string s);
        void ReadAll(IList<string> list);
        void Clear();
        void AddResult(string s);
        
    }
}
