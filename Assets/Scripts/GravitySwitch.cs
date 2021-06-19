using EventBroker;
using Events;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    [SerializeField] private Direction direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(direction));
        }

        if (other.CompareTag("Player"))
        {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(direction));
        }
    }
}
