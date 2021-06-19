using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TimeSlow))]
public class Clock : MonoBehaviour
{
    public UnityEvent onTimerStarted;
    public UnityEvent onTimerFinished;
    
    private GameObject clockHand;
    private TextMesh clockText;
    private TimeSlow timeSlow;
    private IEnumerator timer;

    private void Awake()
    {
        clockHand = GetComponentInChildren<ClockHand>().gameObject;
        clockText = GetComponentInChildren<TextMesh>();
        timeSlow = GetComponent<TimeSlow>();
    }

    public void Begin()
    {
        if (timer != null) return;

        timer = StartTimer();
        StartCoroutine(timer);
    }

    private IEnumerator StartTimer()
    {
        onTimerStarted?.Invoke();
        
        var angle = Mathf.Abs(360 - clockHand.transform.localEulerAngles.z);
        
        while (angle >= 1f)
        {
            timeSlow.SlowTime();
            angle = Mathf.Abs(360 - clockHand.transform.localEulerAngles.z);
            if (angle > 350) break;
            clockText.text = $"{angle/6:00:00}";
            yield return null;
        }
        timeSlow.NormalTime();
        onTimerFinished?.Invoke();
        timer = null;
    }
}
