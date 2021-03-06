using Player;
using UnityEngine;

namespace PhysicsObjects
{
    public class SquishObject : MonoBehaviour
    {
        public int squishAmount = 10;
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<PlayerHealth>(out var health))
            {
                var rb2d = GetComponent<Rigidbody2D>();
                var hitAmount = rb2d.velocity.magnitude;
                var playerVelocity = other.rigidbody.velocity.magnitude;
                var squishSfx = GetComponent<AudioSource>();
                if (hitAmount < playerVelocity)
                    return;
                health.TakeDamage(squishAmount);
                squishSfx.Play();
            }
        }
    }
}
