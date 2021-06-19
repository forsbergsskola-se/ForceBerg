using System.Collections;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

[RequireComponent(typeof(TimeSlow))]
public class Clock : MonoBehaviour
{
    public bool IsTickingDown => Angle >= 1f && Angle <= 350;
    public float Angle => Mathf.Abs(360 - clockHand.transform.localEulerAngles.z);
    
    
    private GameObject clockHand;
    private TextMesh clockText;
    private TimeSlow timeSlow;
    private IEnumerator timer;
    private bool gameIsPaused;
    
    private void Awake()
    {
        clockHand = GetComponentInChildren<ClockHand>().gameObject;
        clockText = GetComponentInChildren<TextMesh>();
        timeSlow = GetComponent<TimeSlow>();
    }

    private void OnEnable() =>
        MessageHandler.Instance().SubscribeMessage<EventGamePaused>(OnGameIsPaused);

    private void OnDisable() =>
        MessageHandler.Instance().UnsubscribeMessage<EventGamePaused>(OnGameIsPaused);
    
    public void StartSlowTimeIfNotInProgress()
    {
        if (timer != null) return;

        timer = SlowTime();
        StartCoroutine(timer);
    }
    
    private void OnGameIsPaused(EventGamePaused eventGamePaused)
        => gameIsPaused = eventGamePaused.IsPaused;

    private IEnumerator SlowTime()
    {
        while (IsTickingDown)
        {
            while (gameIsPaused)
                yield return null;
            
            timeSlow.SlowTime();
            
            clockText.text = $"{Angle/6:00:00}";
            yield return new WaitForSeconds(0.1f);
        }

        clockText.text = "--:--";
        timeSlow.NormalTime();
        timer = null;
    }
}
