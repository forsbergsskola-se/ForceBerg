using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public LayerMask inflateChecks;
    public float distanceToCheck = 0.1f;
    public Transform modelTransform;
    public int healthPerRegen;
    public float maxHealth = 100;
    public float maxWidth = 1.6f;
    public float minHeight = 0.4f;
    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    public float Health
    {
        get => health;
        private set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            modelTransform.localScale = new Vector3(Mathf.Lerp(maxWidth, 1.0f, health / maxHealth),
                Mathf.Lerp(minHeight, 1.0f, health / maxHealth), 1);
        } 
    }

    [ContextMenu("TakeDamage")]
    public void TakeDamage()
    {
        TakeDamage(10);
    }
    
    public void TakeDamage(int amount)
    {
        Health -= amount;
    }
    
    public void Increase()
    {
        // var hit = Physics2D.Raycast(upTransform.position, Vector2.up, transform.lossyScale.y / 2 * distanceToCheck, inflateChecks);
        // Debug.DrawRay(upTransform.position, Vector2.up * ((transform.lossyScale.y / 2) * distanceToCheck), Color.red, 10f);
        // Debug.Log(hit.collider);
        // if (hit.collider == null)
        Health += healthPerRegen * Time.deltaTime;
    }
}