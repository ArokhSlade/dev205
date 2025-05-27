using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAgent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool mouseMoveActive;
        
    PlayerAgent agent;

    [SerializeField]
    private LayerMask groundLayer;

    private Camera cam;

    private PlayerInput input;

    private void Awake()
    {
        cam = Camera.main;
        input = GetComponent<PlayerInput>();
        agent = GetComponent<PlayerAgent>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (mouseMoveActive)
        {
            MouseMove();
        }
        else
        {
            KeyboardMove();
        }
    }

    private void MouseMove()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (input.LeftMouseClicked)
        {
            Debug.LogError("Clicked");

            Ray ray = cam.ScreenPointToRay(input.MousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, groundLayer))
            {
                agent.MoveToTarget(hit.point);
            }
        }
    }

    private void KeyboardMove()
    {
        Vector2 movementVector = input.MoveInput;

        Vector3 targetPosition = transform.position;
        targetPosition.x += movementVector.x;
        targetPosition.z += movementVector.y;
        agent.MoveToTarget(targetPosition);

    }
}
