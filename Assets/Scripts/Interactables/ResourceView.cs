using System;
using TMPro;
using UnityEngine;

namespace DEV205.Interactables
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private TMP_Text amountText;


        private void OnEnable()
        {
            Inventory.ResourceChanged += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            uint amount = Inventory.Instance.GetResourceValue(resourceType);
            amountText.text = amount.ToString();
        }
        private void UpdateView(ResourceType type, uint amount)
        {
            if (this.resourceType == type)
            {
                amountText.text = amount.ToString();
            }
        }


        private void OnDisable()
        {
            Inventory.ResourceChanged -= UpdateView;
        }
    }
}