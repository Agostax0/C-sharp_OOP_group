namespace OOP21_Calculator.Lepore
{
    interface IManager
    {
        IMemoryManager Memory { get; }
        IEngineManager Engine { get; }
    }
}
