namespace OOP21_Calculator.Lepore
{
    public class CCManager : IManager
    {

        private readonly IMemoryManager memManager;
        private readonly IEngineManager engManager;
       
        public CCManager()
        {
            memManager = new CCMemoryManager();
            engManager = new CCEngineManager(memManager);
        }

        public IMemoryManager Memory { get => memManager; }
        public IEngineManager Engine { get => engManager; }
    }
}
