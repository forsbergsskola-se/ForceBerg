using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    public float timeScale = 0.5f;
    private PlayerStamina stamina;
    
    void Start() {
        stamina = FindObjectOfType<PlayerStamina>(); //todo if this is on the player, change to GetComponent
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (stamina.IsNotEmpty)
                SlowTime();
            else
                NormalTime();
        }
        else
            NormalTime();
    }

    public void SlowTime() {
        //stamina.Decrease();
        Time.timeScale = timeScale;
    }

    public void NormalTime() =>
        Time.timeScale = 1f;
}
