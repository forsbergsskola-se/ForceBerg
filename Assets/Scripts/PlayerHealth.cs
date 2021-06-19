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
        if (CanInflate())
        {
            Health += healthPerRegen * Time.deltaTime;
        }
    }

    private bool CanInflate()
    {
        return CheckOneDirection(Vector2.up) || CheckOneDirection(Vector2.down);
    }

    private bool CheckOneDirection(Vector2 direction)
    {
        var position = modelTransform.position;
        var lossyScale = modelTransform.lossyScale;
        var hit = Physics2D.Raycast(position, direction, lossyScale.y + distanceToCheck, inflateChecks);
        if (hit.collider != null)
            return false;
        hit = Physics2D.Raycast(new Vector2(position.x + lossyScale.x/2, position.y), direction, lossyScale.y + distanceToCheck, inflateChecks);
        if (hit.collider != null)
            return false;
        hit = Physics2D.Raycast(new Vector2(position.x - lossyScale.x/2, position.y), direction, lossyScale.y + distanceToCheck, inflateChecks);
        return hit.collider == null;
    }
}