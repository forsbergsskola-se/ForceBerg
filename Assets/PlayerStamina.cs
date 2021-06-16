using System;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float amount;
    public float decreasePerSecond;
    public float regenPerSecond;
    public float maxAmount;
    private bool isRegenerating;
    public bool IsNotEmpty => Amount > 0;

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
}
