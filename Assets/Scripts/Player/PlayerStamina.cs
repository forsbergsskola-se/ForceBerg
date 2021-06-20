using System.Collections;
using Events;
using UnityEngine;

namespace Player
{
    public class PlayerStamina : MonoBehaviour
    {
        public float maxAmount;
        public float decreasePerSecond;
        public float regenPerSecond;
        public float regenDelay;
        private float amount;
        private IEnumerator regeneration;
    
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
                MessageHandler.Instance().SendMessage(new StaminaAmountEvent(amount / maxAmount));
            }
        }

        public void Decrease()
        {
            if (regeneration != null)
            {
                StopCoroutine(regeneration);
            }
            Amount -= decreasePerSecond * Time.deltaTime;
            regeneration = DelayedRegen();
            StartCoroutine(regeneration);
        }

        IEnumerator DelayedRegen()
        {
            yield return new WaitForSeconds(regenDelay);
            while (true)
            {
                Amount += regenPerSecond * Time.deltaTime;
                yield return null;
            }
        }

        private void OnValidate()
        {
            maxAmount = Mathf.Clamp(maxAmount, 0, float.MaxValue);
        }
    }
}