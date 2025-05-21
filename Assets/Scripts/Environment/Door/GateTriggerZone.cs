using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class GateTriggerZone : MonoBehaviour
{
    [SerializeField]
    private Door gate;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        gate.Open();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        gate.Close();
    }
}
