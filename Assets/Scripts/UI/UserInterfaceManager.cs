using Unity.VisualScripting;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    private static UserInterfaceManager instance;

    public static UserInterfaceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (new GameObject("UserInterfaceManager")).AddComponent<UserInterfaceManager>();
                DontDestroyOnLoad(instance);
            }

            return instance;
        }
        
    }

    [SerializeField]
    private PauseWindow pauseWindow;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseWindow.Show();
        }
    }
}
