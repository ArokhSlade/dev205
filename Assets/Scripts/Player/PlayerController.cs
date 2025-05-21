using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    private LayerMask groundLayer;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButton(0)) //LMB
        {
            Debug.LogError("Clicked");

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, groundLayer))
            {
                agent.destination = hit.point;
                Debug.LogError("Hit on: " + hit.point);
            }
        }
    }
}
