using EventBroker;
using Events;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle timerToggle;
    public Slider musicSlider;

    private bool TimerToggle
    {
        get
        {
            var asInt = PlayerPrefs.GetInt("timerToggle", 0);
            return asInt != 0;
        }
        set
        {
            var asInt = value ? 1 : 0;
            PlayerPrefs.SetInt("timerToggle", asInt);
        }
    }

    private float MusicVolume
    {
        get => PlayerPrefs.GetFloat("musicVolume", 0.5f);
        set
        {
            PlayerPrefs.SetFloat("musicVolume", value);
            MessageHandler.Instance().SendMessage(new MusicVolumeEvent(value));
        } 
    }

    private void Awake()
    {
        timerToggle.isOn = TimerToggle;
        timerToggle.onValueChanged.AddListener(TimerToggleOnChange);
        musicSlider.value = MusicVolume;
        musicSlider.onValueChanged.AddListener(MusicVolumeOnChange);
    }

    private void MusicVolumeOnChange(float value)
    {
        MusicVolume = value;
    }

    private void TimerToggleOnChange(bool value)
    {
        TimerToggle = value;
    }
}
