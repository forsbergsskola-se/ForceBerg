using UnityEngine;

public class Destructible : MonoBehaviour, IDestructible
{
    public void Die() => Destroy(gameObject);
}