namespace OOP21_Calculator.Lepore
{
    /// <summary>
    /// The system Manager. 
    /// It contains references to the Memory and Engine Managers.
    /// </summary>
    public class CCManager : IManager
    {

        private readonly IMemoryManager _memManager;
        private readonly IEngineManager _engManager;
       
        public CCManager()
        {
            _memManager = new CCMemoryManager();
            _engManager = new CCEngineManager(_memManager);
        }

        public IMemoryManager Memory => _memManager; 
        public IEngineManager Engine => _engManager; 
    }
}
