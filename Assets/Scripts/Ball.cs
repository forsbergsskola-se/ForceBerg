using System.Collections;
using Traps;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Trap>(out var trap))
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Bounce());
        }
    }

    IEnumerator Bounce()
    {
        float elapsed = 0f;
        transform.localScale = new Vector2(0.8f, 1.2f);
        while (transform.localScale.x < 1 && transform.localScale.y > 1)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, elapsed += Time.deltaTime);
        }
    }
}
