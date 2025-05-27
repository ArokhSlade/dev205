using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAgent : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude / agent.speed);
    }

    public void MoveToTarget(Vector3 position)
    {
        agent.destination = position;
    }
}
