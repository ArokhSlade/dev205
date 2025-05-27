using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool mouseMoveActive;

    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    private LayerMask groundLayer;

    private Camera cam;

    private PlayerInput input;

    private void Awake()
    {
        cam = Camera.main;
        input = GetComponent<PlayerInput>();
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
                agent.destination = hit.point;
                Debug.LogError("Hit on: " + hit.point);
            }
        }
    }

    private void KeyboardMove()
    {
        Vector2 movementVector = input.MoveInput;
        Debug.LogError("MovementVector = " + movementVector);

        Vector3 targetPosition = transform.position;
        targetPosition.x += movementVector.x;
        targetPosition.z += movementVector.y;
        agent.destination = targetPosition;

    }
}
