using UnityEngine;

public class FallingPlatform : MonoBehaviour, IDestructible
{
    private Rigidbody2D rb;
    [SerializeField] private float destroyTime = 1.5f;
    [SerializeField] private Transform bricksParentObject;
    [SerializeField] private GameObject[] onDestroyPrefabs;
    
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
        
        foreach (var block in GetComponentsInChildren<Transform>())
        {
            if(block == transform || block == bricksParentObject) continue;
            
            Instantiate(
                onDestroyPrefabs[Random.Range(0, onDestroyPrefabs.Length)], 
                block.transform.position,
                Quaternion.identity);
        }
        Destroy(gameObject);
        fallingPlatformSfx.Play();
    }

    public void Die() => Destroy(gameObject);
}
