using UnityEngine;

public class Gate : MonoBehaviour, IDoor
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string openDoorParameterName;
    [SerializeField]
    private string closeDoorParameterName;

    public void Close()
    {
        
    }

    public void Open()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
