using UnityEngine;

public class CameraBreathing : MonoBehaviour
{
    public float Amplitude = 0.1f;
    public float Frequency = 0.5f;

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * Frequency) * Amplitude;
        transform.localPosition = _initialPosition + new Vector3(0, offset, 0);
    }
}
