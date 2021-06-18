using System;
using System.Collections;
using EventBroker;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{

    public Transform endPosition;
    public Animator[] cogWheels;
    
    public int triggerKey;
    public float doorOpenSpeed;
    
    private bool doorIsMoving;
    private doorState currentState;
    private Vector2 origPos;
    private Vector2 openPos;


    private float startTime;
    private float distCovered;
    private float fractionOfJourney;
    private float journeyLength;

    private IEnumerator moveDoor;
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");

    private enum doorState
    {
        Open,
        Close
    }

    private void Start()
    {
        origPos = gameObject.transform.position;
        openPos = endPosition.position;

        currentState = doorState.Close;
        
        journeyLength = Vector3.Distance(origPos, openPos);
        
        MessageHandler.Instance().SubscribeMessage<EventTriggerPlate>(SetState);
    }

    private void Update()
    {
        distCovered = (Time.time - startTime) * doorOpenSpeed;
        fractionOfJourney = distCovered / journeyLength;
        
        if(currentState == doorState.Open)
            transform.position = Vector3.Lerp(this.transform.position, openPos, fractionOfJourney);
        else
            transform.position = Vector3.Lerp(this.transform.position, origPos, fractionOfJourney);
    }


    private void SetState(EventTriggerPlate eventMessage)
    {
        if (eventMessage.triggerKey == this.triggerKey)
        {
            if (currentState == doorState.Open)
            {
                startTime = Time.time;
                currentState = doorState.Close;
                foreach (var cogWheel in cogWheels)
                {
                    cogWheel.SetTrigger(Close);
                }
            }
            else
            {
                startTime = Time.time;
                currentState = doorState.Open;
                foreach (var cogWheel in cogWheels)
                {
                    cogWheel.SetTrigger(Open);
                }
            }
        }   
    }

    private void OnDestroy()
    {
        MessageHandler.Instance().UnsubscribeMessage<EventTriggerPlate>(SetState);
    }
}
