namespace Events
{
    public class TimerEvent
    {
        private readonly float timePassed;

        public TimerEvent(float timePassed)
        {
            this.timePassed = timePassed;
        }
    }
}