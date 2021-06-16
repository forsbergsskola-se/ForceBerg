using UnityEngine;

namespace EventBroker.Events
{
    public class EventLevelColorChange
    {
        Color color;
    
        public EventLevelColorChange(Color color)
        {
            this.color = color;
        }
    }
}