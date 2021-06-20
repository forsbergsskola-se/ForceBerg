using System;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        private void Awake()
        {
            if (PlayerPrefs.GetInt("timerToggle", 0) == 0)
            {
                timerText.text = "";
                return;
            }
            MessageHandler.Instance().SubscribeMessage<TimerEvent>(UpdateTimer);
        }

        private void UpdateTimer(TimerEvent obj)
        {
            var timeSpan = TimeSpan.FromSeconds(obj.timePassed);
            timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
        }
    
        private void OnDestroy()
        {
            MessageHandler.Instance().UnsubscribeMessage<TimerEvent>(UpdateTimer);
        }
    }
}