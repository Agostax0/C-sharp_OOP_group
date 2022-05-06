using System.Collections.Generic;
using static OOP21_Calculator.Lepore.IEngineModel;

namespace OOP21_Calculator.Lepore
{
    /// <summary>
    /// Model for the Engine Manager.
    /// It contains a reference to the currently mounted calculator.
    /// </summary>
    public class CCEngineModel : IEngineModel
    {
        private Calculator? _mounted;
        private readonly IDictionary<Calculator, ICalculatorController> _controllers = new Dictionary<Calculator, ICalculatorController>()
        {
            { Calculator.STANDARD, new StandardController() },
            { Calculator.SCIENTIFIC, new ScientificController() }
        };

        public Calculator Mounted { get => _mounted ?? Calculator.STANDARD; set => _mounted = value; }

        public ICalculatorController GetController(Calculator c)
        {
            _controllers.TryGetValue(c, out ICalculatorController contr);
            return contr;
        }
    }
}
