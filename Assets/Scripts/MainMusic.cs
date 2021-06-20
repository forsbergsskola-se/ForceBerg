using Events;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        MessageHandler.Instance().SubscribeMessage<MusicVolumeEvent>(OnMusicVolumeChanged);
    }

    private void OnMusicVolumeChanged(MusicVolumeEvent volumeEvent)
    {
        audioSource.volume = volumeEvent.volume;
    }

    private void OnDestroy()
    {
        MessageHandler.Instance().UnsubscribeMessage<MusicVolumeEvent>(OnMusicVolumeChanged);
    }
}
