﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace DEV205.Interactables
{
    public class Inventory
    {
        public static Action<ResourceType, uint> ResourceChanged;
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

        private Dictionary<ResourceType, uint> resources = new Dictionary<ResourceType, uint>();

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

            if (resources.ContainsKey(data.Type))
            {
                resources[data.Type] += data.Amount;
            }
            else
            {
                resources.Add(data.Type, data.Amount);
            }

            if (ResourceChanged != null)
            {
                ResourceChanged(data.Type, resources[data.Type]);
            }
        }

        public uint GetResourceValue(ResourceType resourceType)
        {
            if (resources.ContainsKey(resourceType))
            {
                return resources[resourceType];
            }
            return 0;
        }
    }
}