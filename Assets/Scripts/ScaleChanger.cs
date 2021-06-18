using UnityEngine;
public class ScaleChanger : MonoBehaviour {
    private Vector3 scaler;
    public float toScaleDown;
    private void Start() {
        scaler = this.transform.localScale; 
    }
    void Update() {
        if (this.transform.lossyScale.y <= 0 || this.transform.lossyScale.x <= 0) return;
        this.transform.localScale = scaler;
        scaler.y -= toScaleDown;
        scaler.x -= toScaleDown;
    }
}
