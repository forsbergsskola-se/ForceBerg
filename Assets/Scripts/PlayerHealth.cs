using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Transform modelTransform;
    public float regenTimeInSeconds;
    public int healthPerRegen;
    public int maxHealth = 100;
    private int health;

    private void Start()
    {
        health = maxHealth;
        StartCoroutine(RegenDamage());
    }

    public int Health
    {
        get => health;
        private set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            modelTransform.localScale = new Vector3(Mathf.Lerp(1.5f, 1.0f, (float) health / maxHealth),
                Mathf.Lerp(0.5f, 1.0f, (float) health / maxHealth), 1);
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

    IEnumerator RegenDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenTimeInSeconds);
            Health += healthPerRegen;
        }
    }
}