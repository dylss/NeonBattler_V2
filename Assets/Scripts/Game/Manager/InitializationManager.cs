using Core.Utilities;

namespace Manager
{
    public class InitializationManager : PersistentSingleton<InitializationManager>
    {
        public float InitializationProgress { get; set; }

        public void Initialize()
        {
            
        }

        public bool IsDoneInitializing()
        {
            return true;
        }
    }
}