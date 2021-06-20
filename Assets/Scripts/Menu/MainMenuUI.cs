using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenuUI : MonoBehaviour
    {
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
#elif !UNITY_WEBGL
        Application.Quit();
#endif
        }
    }
}