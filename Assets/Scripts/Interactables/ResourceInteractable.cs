using System;
using UnityEngine;

namespace DEV205.Interactables
{
    public class ResourceInteractable : Interactable
    {
        public static Action<ResourceData> ResourceCollected;

        [SerializeField] private ResourceData data;
        protected override void Interact()
        {
            if (ResourceCollected != null)
            {
                ResourceCollected(data);
            }
            Destroy(gameObject);
        }
    }
}