using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    [SerializeField, Header("Input Action Asset")]
    private InputActionAsset playerActionAsset;
    [SerializeField]
    private string playerActionMapName;
    [SerializeField]
    private string mousePositionActionName;
    [SerializeField]
    private string mouseInteractionActionName;

    private InputAction mousePositionAction;
    private InputAction mouseInteractionAction;
}
