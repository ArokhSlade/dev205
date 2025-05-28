using System;
using UnityEngine;

namespace DEV205.Interactables
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField]
        private ResourceType resourceType;

        private void OnEnable()
        {
            Inventory.ResourceChanged += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            uint amount = Inventory.Instance.GetResourceValue(resourceType);
            // set value to text display
        }
        private void UpdateView(ResourceType type, uint arg2)
        {
            if (this.resourceType == type)
            {
                // set value to text display
            }
        }


        private void OnDisable()
        {
            Inventory.ResourceChanged -= UpdateView;
        }
    }
}