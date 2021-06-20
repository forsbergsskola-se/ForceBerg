using UnityEngine;

namespace TimeManipulation
{
    public class TimeSlow : MonoBehaviour
    {
        public float timeScale = 0.5f;

        public void SlowTime() => Time.timeScale = timeScale;

        public void NormalTime() => Time.timeScale = 1f;
    }
}
