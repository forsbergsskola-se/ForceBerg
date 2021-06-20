using UnityEngine;

namespace CreditsUI
{
    public class BubblesOnCanvas : MonoBehaviour
    {
        public float moveSpeed;
        Vector3 target;
        public float speedOfChangingTarget;
        private float camHeight;
        private float camWidth;
        public float circleRadius;
        SpriteRenderer spriteRenderer;
        void Start()
        {
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;
            spriteRenderer = GetComponent<SpriteRenderer>();
            InvokeRepeating(nameof(GenerateNewTarget), 0f, speedOfChangingTarget);
        }

        void Update()
        {
            circleRadius = spriteRenderer.bounds.size.x / 2;
            Vector3 currentPos = transform.position;
            if (currentPos == target)
            {
                GenerateNewTarget();
            }
            transform.position = Vector3.MoveTowards(currentPos, target, Time.deltaTime*moveSpeed);
        }
    
        void GenerateNewTarget()
        {
            target = new Vector3
                (Random.Range(-(camWidth / 2-circleRadius), camWidth / 2 - circleRadius), Random.Range(-(camHeight / 2 - circleRadius), camHeight / 2 - circleRadius), 0);
        }
    }
}
