using static OOP21_Calculator.Lepore.IEngineModel;

namespace OOP21_Calculator.Lepore
{
    public interface IEngineManager
    {
        Calculator Mounted { get; set; }
        void Calculate();
    }
}
