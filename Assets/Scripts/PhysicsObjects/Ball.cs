using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour, IDestructible
{
    [SerializeField] private Vector2 bounceScale;
    [SerializeField] private float bounceThreshold;
    [SerializeField] private GameObject destroyedBallPrefab;

    private bool inProgress = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (transform.GetComponent<Rigidbody2D>().velocity.magnitude < bounceThreshold)
            return;
        if (inProgress) {
            StopCoroutine(Bounce());
            transform.localScale = Vector3.one;
        }
        StartCoroutine(Bounce());
    }

    private IEnumerator Bounce()
    {
        inProgress = true;
        
        float elapsed = 0f;
        transform.localScale = new Vector2(bounceScale.x, bounceScale.y);
        while (transform.localScale.x != 1 || transform.localScale.y != 1)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(bounceScale, Vector3.one, elapsed);
            elapsed += Time.deltaTime * 2;
        }
        inProgress = false;
    }

    public void Die()
    {
        Destroy(gameObject);
        var destroyedBall = Instantiate(destroyedBallPrefab, this.transform.position, Quaternion.identity);
        Destroy(destroyedBall, 5f);
    }
}
