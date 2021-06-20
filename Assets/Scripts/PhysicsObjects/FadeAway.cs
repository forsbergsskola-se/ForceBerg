using UnityEngine;

namespace PhysicsObjects
{
    public class FadeAway : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        
        private void Start() {
            spriteRenderer = GetComponent<SpriteRenderer>();
            Destroy(gameObject, 1.2f);
        }
        
        private void Update() {
            if (spriteRenderer.color.a <= 0) return;
            var color = spriteRenderer.color;
            color.a -= 0.002f;
            spriteRenderer.color = color;
        }
    }
}