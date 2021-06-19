namespace Events
{
    public class TimerEvent
    {
        public readonly float timePassed;

        public TimerEvent(float timePassed)
        {
            this.timePassed = timePassed;
        }
    }
}