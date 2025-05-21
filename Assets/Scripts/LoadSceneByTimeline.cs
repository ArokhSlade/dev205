using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LoadSceneByTimeline : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director;

    private int chosenIndex = -1;
    private bool loadingStarted = false;

    public void LoadSceneByIndex(int index)
    {
        if (!loadingStarted)
        {
            loadingStarted = true;
            chosenIndex = index;
            director.Play();
        }
    }

    public void LoadScene()
    {
        if (chosenIndex > -1)
        {
            SceneManager.LoadScene(chosenIndex);
        }
    }
}
