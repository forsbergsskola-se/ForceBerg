using System.Collections;
using UnityEngine;

namespace TimeManipulation
{
    [RequireComponent(typeof(TimeSlow))]
    public class Clock : MonoBehaviour
    {
        public bool IsTickingDown => Angle >= 1f && Angle <= 350;
        public float Angle => Mathf.Abs(360 - clockHand.transform.localEulerAngles.z);
    
    
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

        public void StartSlowTimeIfNotInProgress()
        {
            if (timer != null) return;

            timer = SlowTime();
            StartCoroutine(timer);
        }

        private IEnumerator SlowTime()
        {
            while (IsTickingDown)
            {
                timeSlow.SlowTime();
            
                clockText.text = $"{Angle/6:00:00}";
                yield return new WaitForSeconds(0.1f);
            }

            clockText.text = "--:--";
            timeSlow.NormalTime();
            timer = null;
        }
    }
}
