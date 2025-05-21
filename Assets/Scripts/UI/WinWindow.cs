using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinWindow : BaseWindow
{
    [SerializeField]
    private SceneLoader sceneLoader;

    public override void Show()
    {
        base.Show();
        Time.timeScale = 0.0f;
    }

    public override void Hide()
    {
        base.Hide();
        Time.timeScale = 1.0f;
    }

    public void OnNextLevelButtonPressed()
    {        
        Hide();

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);

        Debug.Log(SceneManager.GetActiveScene().name);
        sceneLoader.LoadSceneByIndex(4);
    }
}
