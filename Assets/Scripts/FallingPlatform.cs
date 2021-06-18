using UnityEngine;

public class FallingPlatform : MonoBehaviour, IDestructible
{
    private Rigidbody2D rb;
    [SerializeField] private float destroyTime = 1.5f;
    private AudioSource fallingPlatformSfx;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        fallingPlatformSfx = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyTime);
        fallingPlatformSfx.Play();
    }

    public void Die() => Destroy(gameObject);
}
