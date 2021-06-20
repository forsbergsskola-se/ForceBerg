using System;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour, IDestructible
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject onDestroyPrefab;
    
    private AudioSource fallingPlatformSfx;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        fallingPlatformSfx = GetComponent<AudioSource>();
        GetComponent<CompositeCollider2D>().GenerateGeometry();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) 
            return;
        Die();
    }

    public void Die()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        fallingPlatformSfx.PlayOneShot(fallingPlatformSfx.clip);
        foreach (var child in GetComponentsInChildren<Transform>())
        {
            if(child == transform || child.name == "Model") 
                continue;
            AddPhysics(child);
        }
        Destroy(gameObject, fallingPlatformSfx.clip.length);
    }

    private void AddPhysics(Transform child)
    {
        child.AddComponent<Rigidbody2D>();
        child.parent = null;
        var destructible = child.AddComponent<Destructible>();
        destructible.destroyedPrefab = onDestroyPrefab;
        destructible.destroyDelay = 3f;
    }

    private void OnValidate()
    {
        GenerateCollider();
    }

    [ContextMenu("GenerateCompositeCollider")]
    public void GenerateCollider()
    {
        if (TryGetComponent<CompositeCollider2D>(out var compositeCollider2D))
        {
            compositeCollider2D.GenerateGeometry();
        }
    }
}
