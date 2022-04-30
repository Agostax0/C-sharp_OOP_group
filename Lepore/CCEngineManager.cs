using System;
using System.Collections.Generic;

namespace OOP21_Calculator.Lepore
{
    class CCEngineManager : IEngineManager
    {
        private readonly IMemoryManager memoryManager;
        private Calculator? mountedCalc;

        public enum Calculator
        {
            STANDARD, SCIENTIFIC
        }

        public CCEngineManager(IMemoryManager memory)
        {
            memoryManager = memory;
            mountedCalc = null;
        }

        public Calculator? Mounted { 
            get => mountedCalc; 
            set {
                Logger.log("Mount", value.ToString());
                mountedCalc = value; 
            }
        }

        public void Calculate()
        {
            IList<string> input = memoryManager.State;
            Logger.log("Calculating", input);

            IEngine engine = new CCEngine(Mounted.Value);
            double result = engine.Calculate(input);
            memoryManager.State = new List<string> { result.ToString() };
        }
    }
}
