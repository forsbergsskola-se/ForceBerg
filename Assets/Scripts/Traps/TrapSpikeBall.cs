using PhysicsObjects.Magnetism;
using UnityEngine;

namespace Traps
{
    public class TrapSpikeBall : Trap, IMagnetic
    {
        private Rigidbody2D rb;

        private void OnEnable()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Attract(Magnet magnet)
        {
            var direction = (magnet.transform.position - transform.position).normalized;
            rb.AddForce(direction * (magnet.attraction * Time.deltaTime));
        }
    }
}
