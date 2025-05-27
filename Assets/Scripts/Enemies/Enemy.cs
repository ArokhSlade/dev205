using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private Animator animator;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = player.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude / agent.speed);
    }

}
