using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    /// <summary>
    /// Memory Manager of the system.
    /// It provides methods for manipulating the input buffer and retrieving the result of a calculation.
    /// </summary>
    public class CCMemoryManager : IMemoryManager
    {
        private readonly IMemoryModel _model = new CCMemoryModel();

        public IList<string> State { get => _model.State; set { _model.ClearBuffer(); ReadAll(value); } }

        public IList<string> History => _model.History;

        public void Read(string s)
        {
            _model.AddInput(s);
        }

        public void ReadAll(IList<string> list)
        {
            foreach (string s in list)
            {
                Read(s);
            }
        }

        public void Clear() => _model.ClearBuffer();

        public void AddResult(string s) => _model.AddToHistory(s);

        public void DeleteLast()
        {
            var curr = State;
            curr.RemoveAt(curr.Count - 1);
            Clear();
            ReadAll(curr);
        }
        
    }
}
