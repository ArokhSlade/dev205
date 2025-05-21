using System;
using UnityEngine;
using UnityEngine.UI; // Button

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private int levelToLoadIndex;

    [SerializeField]
    private string levelName;

    private void Awake()
    {
        if (string.IsNullOrEmpty(levelName))
        {
            GetComponent<Button>().interactable = true;
            return;
        }

        bool isLevelAvailable = Convert.ToBoolean(PlayerPrefs.GetInt(levelName, 0));
        GetComponent<Button>().interactable = isLevelAvailable;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        sceneLoader.LoadSceneByIndex(levelToLoadIndex);
    }
}
