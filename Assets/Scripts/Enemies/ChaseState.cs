using UnityEngine;

namespace DEV205.Enemy
{
    public class ChaseState : BaseState, IState
    {
        private GameObject player;
        public void Enter()
        {
            player = GameObject.FindWithTag("Player");
            agent.speed = speed;
        }

        public void UpdateState()
        {
            agent.destination = player.transform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude / agent.speed);
        }
    }
}
