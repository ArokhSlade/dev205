using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private int sceneIndexToLoad;

    [SerializeField]
    private WinWindow winWindow;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        // [TODO] show win window
        ShowWinWindow();        
    }

    private void ShowWinWindow()
    {
        winWindow.Show();
    }
}


