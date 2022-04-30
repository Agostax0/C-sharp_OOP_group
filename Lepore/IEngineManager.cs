using static OOP21_Calculator.Lepore.CCEngineManager;

namespace OOP21_Calculator.Lepore
{
    interface IEngineManager
    {
        Calculator? Mounted { get; set; }
        void Calculate();
    }
}
