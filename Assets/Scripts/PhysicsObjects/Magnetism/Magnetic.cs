using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Magnetic : MonoBehaviour, IMagnetic
{
    [SerializeField] private Rigidbody2D rigidbody;

    private void OnValidate()
    {
        if(rigidbody == null)
        {
            var tmpRigidbody = GetComponentInParent<Rigidbody2D>();
            if (tmpRigidbody == null)
                Debug.LogError($"{name} doesnt have a RigidBody");
            else
                rigidbody = tmpRigidbody;
        }
    }

    public void Attract(Magnet magnet)
    {
        var direction = (magnet.transform.position - transform.position).normalized;
        rigidbody.AddForce(direction * (magnet.attraction * Time.deltaTime));
    }
}