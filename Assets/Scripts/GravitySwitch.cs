using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    [SerializeField] private Direction direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            Debug.Log("Gravity changed from switch to : "+direction);
            MessageHandler.Instance().SendMessage(new EventGravityChanged(direction));
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Gravity changed from switch to : "+direction);
            MessageHandler.Instance().SendMessage(new EventGravityChanged(direction));
        }
    }
}
