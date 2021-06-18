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
            // if (doorIsMoving)
            // {
            //     if (currentState == doorState.Open)
            //     {
            //         StopCoroutine(moveDoor);
            //         moveDoor = MoveDoor();
            //         StartCoroutine(moveDoor);   
            //     }
            //     else
            //     {
            //         StopCoroutine(moveDoor);
            //         moveDoor = MoveDoor();
            //         StartCoroutine(moveDoor); 
            //     }
            // }
            // else
            // {
            //     if (currentState == doorState.Close)
            //     {
            //         moveDoor = MoveDoor();
            //         StartCoroutine(moveDoor);
            //     }
            //     else
            //     {
            //         moveDoor = MoveDoor();
            //         StartCoroutine(moveDoor);
            //     }
            // }
        }   
    }


    float GetDistanceRemainingInPercentage()
    {
        if (currentState == doorState.Open)
        {
            var distance = transform.position.y - openPos.y;
            var originalDistance = openPos.y - origPos.y;
            var percentage = distance / originalDistance;

            return percentage;
        }
        else
        {
            var distance = origPos.y - transform.position.y;
            var originalDistance = openPos.y - origPos.y;
            var percentage = distance / originalDistance;

            return percentage;
        }
    }

    IEnumerator MoveDoor()
    {
        doorIsMoving = true;

        //var timeElapsed = GetDistanceRemainingInPercentage();
        var timeElapsed = 0.0f;

        while (true)
        {
            if (this.currentState == doorState.Open)
            {
                float newYValue = Mathf.Lerp(transform.position.y, origPos.y, timeElapsed);
                this.transform.position = new Vector3(this.transform.position.x, newYValue, this.transform.position.z);
            }
            else
            {
                float newYValue = Mathf.Lerp(openPos.y, transform.position.y, timeElapsed);
                this.transform.position = new Vector3(this.transform.position.x, newYValue, this.transform.position.z);
            }
            
            timeElapsed += Time.deltaTime;
            
            if (timeElapsed >= doorOpenSpeed)
                break;
            
            yield return null;
        }

        if (currentState == doorState.Open)
            currentState = doorState.Close;
        else currentState = doorState.Open;
        
        doorIsMoving = false;
        yield return null;
    }
}
