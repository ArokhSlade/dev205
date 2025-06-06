using System.Collections.Generic;
using UnityEngine;

namespace DEV205.Enemy
{
    public class PatrolState : BaseState, IState
    {
        [SerializeField] private List<Waypoint> waypoints = new List<Waypoint>();
        [SerializeField] private bool shouldWait;
        [SerializeField] private float maxWaitingTime;
        [SerializeField] private float switchDirectionProbability;

        private int currentWaypointIndex;
        private bool moveForward;
        private float currentWaitingTime;
        private bool isPatrolling;
        private bool isWaiting;

        protected override void Awake()
        {
            base.Awake();

            //TODO(Gerald, 2025 05 27): replace with a custom Assert()
            if (waypoints != null && waypoints.Count > 1)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                Debug.LogError("patrol state not set up properly");
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }

        public void Enter()
        {
            Debug.Log("Enter Patrol state!");
            agent.speed = speed;
            SetDestination();
        }

        public void UpdateState()
        {
            if (isPatrolling && agent.remainingDistance < 0.1f)
            {
                isPatrolling = false;

                if (shouldWait)
                {
                    isWaiting = true;
                    currentWaitingTime = 0;
                }
                else
                {
                    NextWaypoint();
                    SetDestination();
                }
            }

            if (isWaiting)
            {
                currentWaitingTime += Time.deltaTime;
                if (currentWaitingTime >= maxWaitingTime)
                {
                    isWaiting = false;
                    NextWaypoint();
                    SetDestination();
                }
                animator.SetFloat("Speed", 0);
            }
            else
            {
                animator.SetFloat("Speed", 0.4f); 
            }


        }

        private void NextWaypoint()
        {
            
            if (Random.Range(0f, 1f) <= switchDirectionProbability )
            {
                moveForward = !moveForward;
            }

            if (moveForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = 0;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = waypoints.Count - 1;
                }
            }
        }

        private void SetDestination()
        {
            Vector3 target = waypoints[currentWaypointIndex].transform.position;
            agent.destination = target;
            isPatrolling = true;
        }
    }
}
