using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.GlobalIllumination;

public class LightFlickering : MonoBehaviour
{
    [SerializeField]
    private Light spotLight;
    public float flickerTime = .5f;

    void Start()
    {
        StartCoroutine(Flicker(flickerTime));

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }
    }

    private IEnumerator Flicker(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            spotLight.enabled = !spotLight.enabled;
        }
    }

}
