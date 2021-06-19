using System.Collections;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

[RequireComponent(typeof(TimeSlow))]
public class Clock : MonoBehaviour
{
    private GameObject clockHand;
    private TextMesh clockText;
    private TimeSlow timeSlow;
    private IEnumerator timer;
    private bool gameIsPaused;
    float Angle => Mathf.Abs(360 - clockHand.transform.localEulerAngles.z);
    
    private void Awake()
    {
        clockHand = GetComponentInChildren<ClockHand>().gameObject;
        clockText = GetComponentInChildren<TextMesh>();
        timeSlow = GetComponent<TimeSlow>();
    }

    private void OnEnable() =>
        MessageHandler.Instance().SubscribeMessage<EventGamePaused>(GameIsPaused);

    private void OnDisable() =>
        MessageHandler.Instance().UnsubscribeMessage<EventGamePaused>(GameIsPaused);
    
    public void StartSlowTimeIfNotInProgress()
    {
        if (timer != null) return;

        timer = SlowTime();
        StartCoroutine(timer);
    }
    
    private void GameIsPaused(EventGamePaused eventGamePaused)
    {
        gameIsPaused = eventGamePaused.IsPaused;
        
    }

    private IEnumerator SlowTime()
    {
        while (Angle >= 1f && Angle <= 350)
        {
            while (gameIsPaused)
                yield return null;
            
            timeSlow.SlowTime();
            
            clockText.text = $"{Angle/6:00:00}";
            yield return new WaitForSeconds(0.1f);
        }
        timeSlow.NormalTime();
        timer = null;
    }
}
