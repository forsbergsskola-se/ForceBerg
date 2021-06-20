using System.Collections.Generic;
using Events;
using UnityEngine;

namespace TriggerObjects
{
    public class TriggerPlate : MonoBehaviour
    {
        public int triggerKey;
        private List<Collider2D> triggering = new List<Collider2D>();
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            triggering.Add(other);
            if(triggering.Count == 1)
                MessageHandler.Instance().SendMessage(new EventTriggerPlate(triggerKey, true));
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            triggering.Remove(other);
            if(triggering.Count == 0)
                MessageHandler.Instance().SendMessage(new EventTriggerPlate(triggerKey, false));
        }
    }
}
