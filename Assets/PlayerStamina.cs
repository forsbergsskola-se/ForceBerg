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
    public bool IsNotEmpty => Amount > 0;

    public float Amount
    {
        get => amount;
        private set => amount = Mathf.Clamp(value, -5, maxAmount);
    }

    public void Decrease()
    {
        Amount -= decreasePerSecond * Time.deltaTime;
    }

    private void Update()
    {
        Amount += regenPerSecond * Time.deltaTime;
        Debug.Log($"Stamina Is {Amount}");
    }
}
