using DEV205.Interactables;
using UnityEngine;

public class Game : MonoBehaviour
{
    private void Awake()
    {
        Inventory.Instance.Initialize();
    }
}