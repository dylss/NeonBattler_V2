namespace DefaultNamespace
{
    public interface ISimulationEventListener
    {
        public void OnStartSimulation();

        public void OnStartBattling();
        
        public void OnEndSimulation();

        public void OnPauseSimulation();

        public void OnResumeSimulation();

        public void OnSpeedUp();

        public void OnSlowDown();
    }
}