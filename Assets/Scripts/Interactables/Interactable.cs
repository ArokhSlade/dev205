using System;
using UnityEngine;

namespace DEV205.Interactables
{
    [RequireComponent(typeof(SphereCollider))]
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private float debugInteractionRadius = 1f;
        [SerializeField] private Color debugColor = Color.cyan;

        private void Start()
        {
            SetInteractRadius();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            Interact();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = debugColor;
            Gizmos.DrawWireSphere(transform.position, debugInteractionRadius);
        }

        private void OnValidate()
        {
            SetInteractRadius();
        }

        private void SetInteractRadius()
        {
            GetComponent<SphereCollider>().radius = debugInteractionRadius;
        }

        protected virtual void Interact()
        {

        }
    }
}