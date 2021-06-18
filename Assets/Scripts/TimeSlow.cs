using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    public float timeScale;
    private PlayerStamina stamina;
    
    void Start()
    {
        stamina = GetComponent<PlayerStamina>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (stamina.IsNotEmpty)
                SlowTime();
            else
                NormalTime();
        }
        else
            NormalTime();
    }

    public void SlowTime()
    {
        stamina.Decrease();
        Time.timeScale = timeScale;
    }

    public void NormalTime()
    {
        Time.timeScale = 1f;
    }
}
