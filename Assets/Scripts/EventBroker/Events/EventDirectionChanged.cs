namespace EventBroker.Events
{
    public class EventDirectionChanged
    {
        public Direction Direction;
    
        public EventDirectionChanged(Direction direction)
        {
            this.Direction = direction;
        }
    }
}