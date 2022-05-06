using System.Collections.Generic;

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

        public IList<string> State => _buffer;

        public IList<string> History => _history;

        public void AddInput(string s) => _buffer.Add(s);
        
        public void AddToHistory(string s) => _history.Add(s);
        
        public void ClearBuffer() => _buffer.Clear();
        
    }
}
