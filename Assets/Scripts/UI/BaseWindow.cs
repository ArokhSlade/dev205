using UnityEngine;

public class BaseWindow : MonoBehaviour, IWindow
{
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

}
