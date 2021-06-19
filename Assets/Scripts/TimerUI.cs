using System;
using EventBroker;
using Events;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private void Awake()
    {
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