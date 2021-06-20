using UnityEngine;

namespace PhysicsObjects
{
    public class Fragile : MonoBehaviour
    {
        [SerializeField] public GameObject destroyedPrefab;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Fragile>() != null || 
                other.gameObject.GetComponent<FadeAway>() != null) return;
            
            if (destroyedPrefab == null)
                return;
            
            Destroy(Instantiate(destroyedPrefab, transform.position, Quaternion.identity), 2f);
            Destroy(gameObject);
        }
    }
}