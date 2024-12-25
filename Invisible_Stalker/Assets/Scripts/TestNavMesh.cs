using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMesh : MonoBehaviour
{
    public Transform _target;
    public NavMeshAgent _agent;

    private void Update()
    {
        _agent.SetDestination(_target.position);
    }
}
