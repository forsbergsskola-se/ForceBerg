using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float force;
    public Vector2 direction;

    private void OnCollisionStay2D(Collision2D other)
    {
        other.rigidbody.AddForce(direction * force * Time.fixedDeltaTime);
    }
}
