namespace Events
{
    public class EventGravityChanged
    {
        public Direction Direction;
    
        public EventGravityChanged(Direction direction)
        {
            this.Direction = direction;
        }
    }
}