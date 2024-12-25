using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMonstre : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private float _monsterSpeed;

    [SerializeField]
    private float _delayOfStun;

    private void Start()
    {
        _agent.speed = _monsterSpeed;
    }

    private void Update()
    {
        _agent.SetDestination(_target.position);
    }

    public void StunMonster()
    {
        StopAllCoroutines();
        StartCoroutine(Stun());
    }

    IEnumerator Stun()
    {
        _agent.speed = 0;
        yield return new WaitForSeconds(_delayOfStun);
        _agent.speed = _monsterSpeed;
    }
}
