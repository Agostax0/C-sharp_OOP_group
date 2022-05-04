using System;
using System.Collections.Generic;
using System.Globalization;
using static OOP21_Calculator.Lepore.IEngineModel;

namespace OOP21_Calculator.Lepore
{
    /// <summary>
    /// Engine manager of the system.
    /// It provides methods for selecting the calculator to use and to calculate the expression currently stored in the memory manager.
    /// </summary>
    public class CCEngineManager : IEngineManager
    {
        private readonly IMemoryManager _memoryManager;
        private readonly IEngineModel _model;

        public CCEngineManager(IMemoryManager memory)
        {
            _memoryManager = memory;
            _model = new CCEngineModel();
        }

        public Calculator Mounted { 
            get => _model.Mounted; 
            set => _model.Mounted = value; 
        }

        public void Calculate()
        {
            IList<string> input = _memoryManager.State;

            IEngine engine = new CCEngine(_model.GetController(Mounted));

            try
            {
                double result = engine.Calculate(input);
                _memoryManager.State = new List<string> { result.ToString(CultureInfo.CreateSpecificCulture("en-GB")) };
            }
            catch (Exception e)
            {
                _memoryManager.State = new List<string> { e.Message };
            }
        }

    }
}
