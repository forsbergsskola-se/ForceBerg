using EventBroker;
using EventBroker.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Setup()
    {
        Time.timeScale = 0.0f;
    }

    public void Disable()
    {
        Time.timeScale = 1.0f;
        Destroy(this.gameObject);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}