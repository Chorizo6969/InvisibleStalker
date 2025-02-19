using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_StartGame : MonoBehaviour
{
    //1st état, initialisation des paramètre de base tels que la vitesse, etc...

    public static AI_StartGame Instance;
    [SerializeField] private NavMeshAgent _agent;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGameAI()
    {
        _agent.speed = 3.5f;
    }
}
