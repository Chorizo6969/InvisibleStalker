using System;
using UnityEngine;

public class Ai_Sensor : MonoBehaviour
{
    public event Action OnPlayerNear;

    public bool PlayerNear { get; private set; }

    [SerializeField] private float detectionRange = 4f;
    [SerializeField] private float menacingRange = 2f;
    [SerializeField] private LayerMask sensorMask;

    public GameObject GetClosestPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, sensorMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out PlayerController player))
            {
                PlayerNear = true;
                OnPlayerNear?.Invoke();
                return player.gameObject;
            }
        }

        PlayerNear = false;
        return null;
    }

    private void Update()
    {
        GetClosestPlayer();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, menacingRange);
    }
}
