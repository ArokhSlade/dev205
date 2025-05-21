using System.Security.Cryptography;
using UnityEngine;

public class PauseWindow : BaseWindow
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

    public void OnContinueButtonClicked()
    {
        Hide();
    }

    public void OnBackToMenuButtonClicked()
    {
        sceneLoader.LoadSceneByIndex(0);
    }

    public void OnQuitButtonClicked()
    {
        sceneLoader.QuitGame();
    }
}
