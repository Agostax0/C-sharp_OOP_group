using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP21_Calculator.Lepore
{
    /// <summary>
    /// Model for the Memory Manager.
    /// It contains a reference to the input buffer.
    /// </summary>
    public class CCMemoryModel : IMemoryModel
    {
        private readonly IList<string> _buffer = new List<string>();
        private readonly IList<string> _history = new List<string>();

        public IList<string> State { get => CopyOf(_buffer);}

        public IList<string> History { get => CopyOf(_history); }

        public void AddInput(string s) => _buffer.Add(s);
        
        public void AddToHistory(string s) => _history.Add(s);
        
        public void ClearBuffer() => _buffer.Clear();

        private IList<string> CopyOf(IList<string> list) => list.ToList();


    }
}
