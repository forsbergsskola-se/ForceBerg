using Events;
using UnityEngine;

namespace Player.Visuals
{
    public class StaminaBar : MonoBehaviour
    {
        public Transform bar;
        private void Awake()
        {
            MessageHandler.Instance().SubscribeMessage<StaminaAmountEvent>(StaminaUpdate);
        }

        private void OnDestroy()
        {
            MessageHandler.Instance().UnsubscribeMessage<StaminaAmountEvent>(StaminaUpdate);
        }

        private void StaminaUpdate(StaminaAmountEvent obj)
        {
            var newPosition = new Vector3(obj.percent/2, bar.localPosition.y, bar.localPosition.z);
            bar.localPosition = newPosition;
        
            var newScale = new Vector3(obj.percent, bar.localScale.y, bar.localScale.z);
            bar.localScale = newScale;
        }
    }
}