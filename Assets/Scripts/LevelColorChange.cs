using EventBroker;
using Events;
using UnityEngine;

public class LevelColorChange : MonoBehaviour
{
    [SerializeField] private Color color;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            MessageHandler.Instance().SendMessage(new EventLevelColorChange(color));
        }

        if (other.CompareTag("Player"))
        {
            MessageHandler.Instance().SendMessage(new EventLevelColorChange(color));
        }
    }
}
