using System;
using System.Collections.Generic;
using System.Globalization;
using static OOP21_Calculator.Lepore.IEngineModel;

namespace OOP21_Calculator.Lepore
{
    public class CCEngineManager : IEngineManager
    {
        private readonly IMemoryManager memoryManager;
        private readonly IEngineModel model;

        public CCEngineManager(IMemoryManager memory)
        {
            memoryManager = memory;
            model = new CCEngineModel();
        }

        public Calculator? Mounted { 
            get => model.Mounted; 
            set {
                Logger.log("Mount", value.ToString());
                model.Mounted = value.Value; 
            }
        }

        public void Calculate()
        {
            IList<string> input = memoryManager.State;
            Logger.log("Calculating", input);

            IEngine engine = new CCEngine(GetController(Mounted.Value));
            double result = engine.Calculate(input);
            memoryManager.State = new List<string> { result.ToString(CultureInfo.CreateSpecificCulture("en-GB")) };
        }

        private ICalculatorController GetController(Calculator c)
        {
            ICalculatorController controller = new StandardController();
            switch(c)
            {
                case Calculator.STANDARD:
                    {
                        controller = new StandardController();
                        break;
                    }
                case Calculator.SCIENTIFIC:
                    {
                        controller = new ScientificController();
                        break;
                    }
            }
            return controller;
        }
    }
}
