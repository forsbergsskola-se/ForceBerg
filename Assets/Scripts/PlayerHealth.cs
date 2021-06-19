using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
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

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Health += healthPerRegen * Time.deltaTime;
        }
    }
}