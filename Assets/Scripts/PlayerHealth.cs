using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Transform modelTransform;
    public int healthPerRegen;
    public float maxHealth = 100;
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
            modelTransform.localScale = new Vector3(Mathf.Lerp(1.5f, 1.0f, health / maxHealth),
                Mathf.Lerp(0.5f, 1.0f, health / maxHealth), 1);
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