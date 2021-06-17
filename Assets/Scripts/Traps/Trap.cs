using EventBroker;
using EventBroker.Events;
using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Collider2D))]
    public class Trap : MonoBehaviour
    {
        private AudioSource bladeSfx;

        void Start() {
            bladeSfx = GetComponent<AudioSource>();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            // if (other.gameObject.TryGetComponent<Player>(out var player))
            // {
            //     Debug.Log("Player collided with Trap : " +this.name);
            //     MessageHandler.Instance().SendMessage(new EventPlayerDeath());
            // }

            if (other.gameObject.TryGetComponent<IDestructible>(out var destructible))
            {
                bladeSfx.Play();
                Debug.Log(other.gameObject.name+" collided with Trap : " +this.name);
                destructible.Die();
            }
        }
    }
}
