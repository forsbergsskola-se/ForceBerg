using PhysicsObjects;
using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Collider2D))]
    public class Trap : MonoBehaviour
    {
        private AudioSource trapSfx;

        void Start() {
            trapSfx = GetComponent<AudioSource>();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IDestructible>(out var destructible))
            {
                trapSfx.Play();
                destructible.Die();
            }
        }
    }
}
