namespace Util
{
    public interface ISimulatorObject
    {
        public void OnStartSimulation();

        public void OnEndSimulation();

        public void OnPauseSimulation();
    }
}