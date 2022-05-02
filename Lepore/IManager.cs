namespace OOP21_Calculator.Lepore
{
    public interface IManager
    {
        IMemoryManager Memory { get; }
        IEngineManager Engine { get; }
    }
}
