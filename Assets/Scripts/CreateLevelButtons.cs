using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateLevelButtons : MonoBehaviour
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
        scenes = sceneAssets.Select(asset => asset.name).ToArray();
    }
    #endif
}