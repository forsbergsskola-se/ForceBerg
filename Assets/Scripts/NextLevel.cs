using Events;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private bool isLastLevel;
    
    private bool FirstCompleted
    {
        get
        {
            var asInt = PlayerPrefs.GetInt("firstCompleted", 1);
            return asInt != 0;
        }
        set
        {
            var asInt = value ? 1 : 0;
            PlayerPrefs.SetInt("firstCompleted", asInt);
        }
    }
    
    private bool TimedMode
    {
        set
        {
            var asInt = value ? 1 : 0;
            PlayerPrefs.SetInt("timerToggle", asInt);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            MessageHandler.Instance().SendMessage(new FinishLevelEvent());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (isLastLevel)
            {
                TurnOnTimedMode();
            }
        }
    }

    private void TurnOnTimedMode()
    {
        if (FirstCompleted)
        {
            TimedMode = true;
            FirstCompleted = false;
        }
    }
}
