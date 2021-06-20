using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class LevelSelect : MonoBehaviour
    {
        public Button buttonPrefab;
#if UNITY_EDITOR
        public UnityEditor.SceneAsset[] sceneAssets;
#endif
        [HideInInspector]
        public string[] scenes;
        private void Awake()
        {
            foreach (var sceneAsset in scenes)
            {
                var button = Instantiate(buttonPrefab, transform);
                button.GetComponentInChildren<Text>().text = sceneAsset.Substring(8);
                button.onClick.AddListener(() => SceneManager.LoadScene(sceneAsset));
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (scenes != sceneAssets.Select(asset => asset.name).ToArray())
            {
                scenes = sceneAssets.Select(asset => asset.name).ToArray();
                UnityEditor.EditorUtility.SetDirty(this);
            }
        }
#endif
    }
}