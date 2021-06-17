using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent unityEvent;
    [TagWrapper]
    public string tagToTriggerOn;
    public bool doOnce;
    private bool hasBeenTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(this.tagToTriggerOn) || hasBeenTriggered) return;
        if (doOnce)
            hasBeenTriggered = true;
        unityEvent.Invoke();
    }
}