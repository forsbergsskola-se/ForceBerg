using UnityEngine;

public class Destructible : MonoBehaviour, IDestructible
{
    public GameObject destroyedPrefab;
    public float destroyDelay = 5f;

    public void Die()
    {
       Destroy(gameObject);
       if (destroyedPrefab == null)
           return;
       var destroyedObject = Instantiate(destroyedPrefab, this.transform.position, Quaternion.identity);
       Destroy(destroyedObject, destroyDelay);
    } 
}