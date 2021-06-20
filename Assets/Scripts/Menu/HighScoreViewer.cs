using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class HighScoreViewer : MonoBehaviour
    {
        public Text buttonPrefab;
#if UNITY_EDITOR
        public UnityEditor.SceneAsset[] sceneAssets;
#endif
        [HideInInspector]
        public string[] scenes;
        private void Awake()
        {
            foreach (var sceneAsset in scenes)
            {
                var highScoreText = Instantiate(buttonPrefab, transform);
                var savedTime = PlayerPrefs.GetFloat(sceneAsset, 0);
                var timeSpan = TimeSpan.FromSeconds(savedTime);
                var timeText = savedTime != 0 ? $"{timeSpan:mm\\:ss\\:ff}" : "N/A";
                highScoreText.text = $"{sceneAsset.Substring(8)}:\n \n" +
                                     $"{timeText}";
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            scenes = sceneAssets.Select(asset => asset.name).ToArray();
        }
#endif
    }
}