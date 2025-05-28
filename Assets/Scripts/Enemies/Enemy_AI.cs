using UnityEngine;
namespace DEV205.Enemy
{
    public class Enemy_AI : MonoBehaviour
    {
        [SerializeField]
        private AIState initAIState;

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
        }

        private void EnterState()
        {

            switch (currentAIState)
            {
                case AIState.None:
                    break;
                case AIState.Chasing:
                    break;
                case AIState.Attacking:
                    break;
                case AIState.Patrolling:
                    break;
                default:
                    break;
            }
        }
    }
}

