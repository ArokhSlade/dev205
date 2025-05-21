using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    [SerializeField]
    public Door door;

    [SerializeField]
    private DoorActionType doorActionType;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        switch (doorActionType)
        {
            case DoorActionType.Open:
                door.Open();
                break;
            case DoorActionType.Close:
                door.Close();
                break; 
            case DoorActionType.None:
            default:
                Debug.LogError("Door Action Type not set or handled yet!");
                break;
        }
    }
}
