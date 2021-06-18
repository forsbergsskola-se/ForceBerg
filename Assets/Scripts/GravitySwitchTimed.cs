using System.Collections;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class GravitySwitchTimed : MonoBehaviour
{
    [SerializeField] private Direction direction;
    [SerializeField] private float duration = 5f;

    private Direction previousDirection;
    private bool inProgress = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (inProgress) return;
            previousDirection = FindObjectOfType<Flipable>().Direction;
            StartCoroutine(GravityTimer());
        }
    }

    private IEnumerator GravityTimer()
    {
        inProgress = true;
        MessageHandler.Instance().SendMessage(new EventGravityChanged(direction));
        yield return new WaitForSeconds(duration);
        MessageHandler.Instance().SendMessage(new EventGravityChanged(previousDirection));
        inProgress = false;
    } 
}
