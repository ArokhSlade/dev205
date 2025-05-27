using UnityEngine;
namespace DEV205.Enemy
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField]
        private Color gizmoColor = Color.white;

        [SerializeField]
        private float debugDrawRadius = 5f;

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, debugDrawRadius);
        }
    }

}