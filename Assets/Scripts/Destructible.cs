using UnityEngine;

public class Destructible : MonoBehaviour, IDestructible
{
    [SerializeField] private GameObject destroyedPrefab;

    public void Die()
    {
       Destroy(gameObject);
       if (destroyedPrefab == null)
           return;
       var destroyedObject = Instantiate(destroyedPrefab, this.transform.position, Quaternion.identity);
       Destroy(destroyedObject, 5f);
    } 
}