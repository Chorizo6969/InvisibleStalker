using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightoff : MonoBehaviour
{
    [SerializeField]
    private List<Light> lights = new List<Light>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            foreach (Light light in lights)
            {
                light.intensity = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            foreach (Light light in lights)
            {
                light.intensity = 109;
            }
        }
    }
}
