using System;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float maxAmount;
    public float decreasePerSecond;
    public float regenPerSecond;
    private float amount;
    private bool isRegenerating;
    public bool IsNotEmpty => Amount > 0;

    private void Start()
    {
        amount = maxAmount;
    }

    public float Amount
    {
        get => amount;
        private set
        {
            amount = Mathf.Clamp(value, -5, maxAmount);
            Debug.Log($"Stamina Is {amount}");
        }
    }

    public void Decrease()
    {
        Amount -= decreasePerSecond * Time.deltaTime;
        isRegenerating = false;
    }
    
    public void BeginRegen()
    {
        isRegenerating = true;
    }

    private void Update()
    {
        if (isRegenerating)
        {
            Amount += regenPerSecond * Time.deltaTime;
        }
    }

    private void OnValidate()
    {
        maxAmount = Mathf.Clamp(maxAmount, 0, float.MaxValue);
    }
}
