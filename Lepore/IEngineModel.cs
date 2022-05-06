namespace OOP21_Calculator.Lepore
{
    public interface IEngineModel
    {
        public enum Calculator
        {
            STANDARD, SCIENTIFIC
        }

        Calculator Mounted { get; set; }

        ICalculatorController GetController(Calculator calculator);
    }
}
