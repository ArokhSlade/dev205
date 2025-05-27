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

    private InputAction mousePositionAction;
    private InputAction mouseInteractionAction;

    private void Awake()
    {
        InputActionMap inputActions = playerActionAsset.FindActionMap(playerActionMapName);
        mousePositionAction = inputActions.FindAction(mousePositionActionName);
        mouseInteractionAction = inputActions.FindAction(mouseInteractionActionName);

        RegisterActions();
    }

    private void OnEnable()
    {
        mousePositionAction.Enable();
        mouseInteractionAction.Enable();
    }

    private void OnDisable()
    {
        mousePositionAction.Disable();
        mouseInteractionAction.Disable();
    }

    private void RegisterActions()
    {
        mousePositionAction.performed += MousePositionActionPerformed;
        //mouseInteractionAction
    }

    private void MousePositionActionPerformed(InputAction.CallbackContext context)
    {
        context.ReadValue<Vector2>();
    }

    private void MousePositionActionPerformed()
    {

    }
}
