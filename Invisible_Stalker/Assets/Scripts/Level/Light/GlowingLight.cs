using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingLight : MonoBehaviour
{
    [SerializeField]
    private List<Light> lights = new List<Light>();

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            foreach (Light light in lights)
            {
                light.intensity = Random.Range(0, 109);
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
