using System;
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
    [SerializeField]
    private string moveActionName;

    private InputAction mousePositionAction;
    private InputAction mouseInteractionAction;
    private InputAction moveAction;

    public Vector2 MoveInput { get; private set; }
    public Vector2 MousePosition { get; private set; }

    public bool LeftMouseClicked
    {
        get
        {
            return mouseInteractionAction.WasPerformedThisFrame();
        }
    }

    private void Awake()
    {

        InputActionMap inputActions = playerActionAsset.FindActionMap(playerActionMapName);
        mousePositionAction = inputActions.FindAction(mousePositionActionName);
        mouseInteractionAction = inputActions.FindAction(mouseInteractionActionName);
        moveAction = inputActions.FindAction(moveActionName);

        RegisterActions();
    }

    private void OnEnable()
    {
        mousePositionAction.Enable();
        mouseInteractionAction.Enable();
        moveAction.Enable();
    }

    private void OnDisable()
    {
        mousePositionAction.Disable();
        mouseInteractionAction.Disable();
        moveAction.Disable();
    }

    private void RegisterActions()
    {
        mousePositionAction.performed += MousePositionActionPerformed;
        moveAction.performed += MoveActionPerformed;
    }

    private void MoveActionPerformed(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void MousePositionActionPerformed(InputAction.CallbackContext context)
    {
        MousePosition = context.ReadValue<Vector2>();
    }
}
