using EventBroker;
using EventBroker.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Setup()
    {
        Time.timeScale = 0.0f;
        MessageHandler.Instance().SendMessage(new EventGamePaused(true));
    }

    public void Disable()
    {
        Time.timeScale = 1.0f;
        MessageHandler.Instance().SendMessage(new EventGamePaused(false));
        Destroy(this.gameObject);
    }

    public void Restart()
    {
        MessageHandler.Instance().SendMessage(new EventGamePaused(false));
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ReturnToMainMenu()
    {
        MessageHandler.Instance().SendMessage(new EventGamePaused(false));
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
