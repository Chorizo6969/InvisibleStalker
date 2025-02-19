using System;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    public void MoveTo(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    public void StopMoving()
    {
        _agent.isStopped = true;
        _agent.velocity = Vector3.zero;
    }

    public void RestartMoving()
    {
        _agent.isStopped = false;
    }

    public bool HasReachedDestination()
    {
        return !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance;
    }

    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }
}
