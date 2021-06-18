using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    // public Text timeText;
    // [SerializeField] float startTime;
    //
    // public Text scoreText;
    // public short startScore;
    // public static short currentScore;
    // [SerializeField] short _endScore;

    void Update() {
        // DisplayTime();
        // IfTimerIsZeroPlayerIsDefeated();
        // NextSceneIfEndScoreIsReached();
        QuitButton();
    }

    // void DisplayTime() {
    //     timeText.text = $"Time left:\n {startTime - Time.timeSinceLevelLoad:0s}";
    // }
    //
    // void IfTimerIsZeroPlayerIsDefeated() {
    //     if (startTime - Time.timeSinceLevelLoad <= 0) SceneManager.LoadScene("Scenes/MainMenu");
    // }
    //
    // void NextSceneIfEndScoreIsReached() {
    //     if (currentScore - startScore >= _endScore)
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    public void FullScreenButton() {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void StartApplicationButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void GoToCreditsButton() {
        SceneManager.LoadScene("Scenes/Credits");
    }
    
    public void GoToMainMenuButton() {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
    public void ExitApplicationButton() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
#endif
    }

    static void QuitButton() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}