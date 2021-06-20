using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Timer
{
    public class LevelTimer : MonoBehaviour
    {
        private float timePassed;
    
        private void UpdateHighScore()
        {
            var highScore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name, 1000000000f);
            if (timePassed < highScore)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, timePassed);
            }
        }
    
        private void Start()
        {
            MessageHandler.Instance().SubscribeMessage<FinishLevelEvent>(OnFinishLevel);
        }

        private void Update()
        {
            timePassed += Time.deltaTime;
            MessageHandler.Instance().SendMessage(new TimerEvent(timePassed));
        }

        private void OnFinishLevel(FinishLevelEvent obj)
        {
            UpdateHighScore();
        }

        private void OnDestroy()
        {
            MessageHandler.Instance().UnsubscribeMessage<FinishLevelEvent>(OnFinishLevel);
        }
    }
}