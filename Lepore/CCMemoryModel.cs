using System;
using System.Collections.Generic;
using System.Text;

namespace OOP21_Calculator.Lepore
{
    public class CCMemoryModel : IMemoryModel
    {
        public IList<string> State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<string> History => throw new NotImplementedException();

        public void AddInput(string s)
        {
            throw new NotImplementedException();
        }

        public void AddToHistory()
        {
            throw new NotImplementedException();
        }

        public void ClearBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
