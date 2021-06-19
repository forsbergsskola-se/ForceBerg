using UnityEngine;

public class ClockHand : MonoBehaviour
{
    private Clock clock;

    private void Start() =>
        clock = GetComponentInParent<Clock>();

    private void OnCollisionExit2D(Collision2D other)
        => clock.StartSlowTimeIfNotInProgress();
}
