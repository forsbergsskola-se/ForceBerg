using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class LevelColorChange : MonoBehaviour
{
    [SerializeField] private Color color;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            Debug.Log("Level color changed to : "+color);
            MessageHandler.Instance().SendMessage(new EventLevelColorChange(color));
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Level color changed to : "+color);
            MessageHandler.Instance().SendMessage(new EventLevelColorChange(color));
        }
    }
}
