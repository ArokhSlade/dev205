using System;
using UnityEngine;

namespace DEV205.Interactables
{
    public class Inventory
    {
        private static Inventory instance;
        public static Inventory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Inventory();
                }
                return instance;
            }
        }

        private bool isInitialized = false;

        private Inventory() {}

        public void Initialize()
        {
            if (!isInitialized)
            {
                ResourceInteractable.ResourceCollected += OnResourceCollected;
                isInitialized = false;
            }
        }

        private void OnResourceCollected(ResourceData data)
        {
            Debug.Log($"Resource collected: {data.Type}");
        }
    }
}