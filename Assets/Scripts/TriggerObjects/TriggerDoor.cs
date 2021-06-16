using EventBroker;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public int triggerKey;

    private void Start()
    {
        MessageHandler.Instance().SubscribeMessage<EventTriggerPlate>(SetState);
    }


    private void SetState(EventTriggerPlate eventMessage)
    {
        if (eventMessage.triggerKey == this.triggerKey)
        {
            this.gameObject.SetActive(!eventMessage.isActive);
        }   
    }
}
