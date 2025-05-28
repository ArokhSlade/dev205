using UnityEngine;

namespace DEV205.Interactables
{
    public class ResourceInteractable : Interactable
    {
        [SerializeField] private ResourceData data;
        protected override void Interact()
        {
            //add to inventory
            Destroy(gameObject);
        }
    }
}