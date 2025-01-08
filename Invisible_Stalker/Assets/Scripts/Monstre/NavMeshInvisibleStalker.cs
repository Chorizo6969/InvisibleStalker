using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshInvisibleStalker : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private float _monsterSpeed;

    [SerializeField]
    private float _delayOfStun;

    private GameObject _futurSpawn;

    public List<GameObject> _potentialSpawn = new List<GameObject>();

    private void Start()
    {
        _agent.speed = _monsterSpeed;
    }

    public void StunMonster()
    {
        StopAllCoroutines();
        SetFuturSpawn();
        StartCoroutine(Stun());
    }

    IEnumerator Stun()
    {
        _agent.speed = 0;
        yield return new WaitForSeconds(0.25f);
        _agent.gameObject.SetActive(false);
        _agent.gameObject.transform.position = _futurSpawn.transform.position;
        yield return new WaitForSeconds(_delayOfStun - 0.25f);
        _agent.gameObject.SetActive(true);
        _agent.speed = _monsterSpeed;
    }

    private void SetFuturSpawn()
    {
        int index = Random.Range(0, _potentialSpawn.Count);
        _futurSpawn = _potentialSpawn[index];
    }
}
