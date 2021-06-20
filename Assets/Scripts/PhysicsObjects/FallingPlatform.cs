using Unity.VisualScripting;
using UnityEngine;

namespace PhysicsObjects
{
    public class FallingPlatform : MonoBehaviour, IDestructible {
    
        [SerializeField] private PlatformBehaviour PlatformInstability;
        [SerializeField] private GameObject onDestroyPrefab;
    
        private Rigidbody2D rb;
        private AudioSource fallingPlatformSfx;
    
        void Start() {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            fallingPlatformSfx = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (!other.gameObject.CompareTag("Player")) 
                return;
            if(PlatformInstability == PlatformBehaviour.OnContact)
                Die();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player")) 
                return;
            if(PlatformInstability == PlatformBehaviour.OnLeaving)
                Die();
        }

        public void Die() {
            gameObject.GetComponent<Collider2D>().enabled = false;
            fallingPlatformSfx.PlayOneShot(fallingPlatformSfx.clip);
            Destroy(gameObject, fallingPlatformSfx.clip.length);
        
            foreach (var child in GetComponentsInChildren<Transform>()) {
            
                if(child == transform || child.name == "Model") 
                    continue;
                AddPhysics(child);
            }
        }

        private void AddPhysics(Transform child) {
            child.AddComponent<Rigidbody2D>();
            child.parent = null;
            var destructible = child.AddComponent<Destructible>();
            destructible.destroyedPrefab = onDestroyPrefab;
            destructible.destroyDelay = 3f;
        }

        [ContextMenu("GenerateCompositeCollider")]
        public void GenerateCollider() {
            if (TryGetComponent<CompositeCollider2D>(out var compositeCollider2D)) 
                compositeCollider2D.GenerateGeometry();
        }
    }
}