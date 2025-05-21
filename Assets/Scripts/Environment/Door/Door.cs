using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshObstacle))]
[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour, IDoor
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string openDoorParameterName;
    [SerializeField]
    private string closeDoorParameterName;

    private bool isOpen;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void Open()
    {
        if (!isOpen)
        {
            animator.SetTrigger(openDoorParameterName);
        }
    }

    public void Close()
    {
        if(isOpen)
        {
            animator.SetTrigger(closeDoorParameterName);
        }
    }

    public void OnOpenDoorAnimationFinished()
    {
        isOpen = true;
    }

    public void OnCloseDoorAnimationFinished()
    {
        isOpen = false;
    }
}
