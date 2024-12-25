using UnityEngine;

public class CameraBreathing : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float frequency = 0.5f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = initialPosition + new Vector3(0, offset, 0);
    }
}
