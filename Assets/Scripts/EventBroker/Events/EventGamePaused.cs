namespace EventBroker.Events
{
    public class EventGamePaused
    {
        public bool IsPaused;

        public EventGamePaused(bool isPaused)
        {
            IsPaused = isPaused;
        }
    }
}