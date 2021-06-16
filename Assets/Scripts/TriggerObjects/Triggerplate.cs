using EventBroker;
using UnityEngine;

public class Triggerplate : MonoBehaviour
{
    public int triggerKey;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        MessageHandler.Instance().SendMessage(new EventTriggerPlate(triggerKey, true));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        MessageHandler.Instance().SendMessage(new EventTriggerPlate(triggerKey, false));
    }
}
