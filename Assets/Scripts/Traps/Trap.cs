using EventBroker;
using EventBroker.Events;
using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Collider2D))]
    public class Trap : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var player))
            {
                Debug.Log("Player collided with Trap : " +this.name);
                MessageHandler.Instance().SendMessage(new EventPlayerDeath());
            }
        }
    }
}
