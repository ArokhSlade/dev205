using TreeEditor;
using UnityEngine;
namespace DEV205.Enemy
{
    public class Enemy_AI : MonoBehaviour
    {
        [SerializeField]
        private AIState initAIState;

        [SerializeField]
        private float chasingRadius;

        [SerializeField]
        private LayerMask playerLayer;

        private AIState currentAIState;

        private IState currentState;

        void Start()
        {
            currentAIState = initAIState;
            EnterState();
        }

        void Update()
        {
            EvaluateState();
            currentState.UpdateState();
        }

        private void EvaluateState()
        {
            // check if player is in range for chasing or not and switch state
            bool playerInChasingRange = Physics.CheckSphere(transform.position, chasingRadius, playerLayer);
            bool isPatrolling = currentAIState == AIState.Patrolling;
            bool isChasing = currentAIState == AIState.Chasing;

            if (!isPatrolling && !playerInChasingRange)
            {
                currentAIState = AIState.Patrolling;
                EnterState();
            }
            else if (!isChasing && playerInChasingRange)
            {
                currentAIState = AIState.Chasing;
                EnterState();
            }
        }

        private void EnterState()
        {
            switch (currentAIState)
            {
                case AIState.Chasing:
                    currentState = GetComponent<ChaseState>();                    
                    break;
                case AIState.Attacking:
                    break;
                case AIState.Patrolling:
                    currentState = GetComponent<PatrolState>();                    
                    break;
                case AIState.None:
                default:
                    Debug.LogError($"Current AI State {currentAIState} not handled yet!");
                    break;
            }
            currentState.Enter();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, chasingRadius);
        }
    }
}

