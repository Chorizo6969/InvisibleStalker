using UnityEngine;
using UnityEngine.AI;

public class SetDestinationScarabee : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform[] _waypoints;  // Liste des waypoints du chemin
    [SerializeField] private float _hoverHeight;  // Hauteur de l'oscillation
    [SerializeField] private float _hoverSpeed;   // Vitesse de l'oscillation
    [SerializeField] private float _fleeDistance = 15f; // Distance de fuite

    private int _currentWaypointIndex = 0;
    private bool _isFleeing;

    private float _baseOffset;

    void Start()
    {
        _baseOffset = _agent.baseOffset;
        _agent.SetDestination(_waypoints[_currentWaypointIndex].position);
    }

    void Update()
    {
        ApplyVerticalOscillation();

        if (_isFleeing) return; 

        FollowPath();
    }

    public void FleeFromPlayer()
    {
        _isFleeing = true;
        _agent.speed = 4;

        // Inverser la direction et s'éloigner du joueur
        Vector3 fleeDirection = (transform.position - _playerTransform.position).normalized;
        Vector3 fleeTarget = transform.position + fleeDirection * _fleeDistance;

        // Chercher un chemin de fuite sur le NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleeTarget, out hit, _fleeDistance, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }
    }

    private void FollowPath()
    {
        if (_waypoints.Length == 0) return;

        // Aller au prochain waypoint
        if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < 1f)
        {
            print("aaled");
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length; // Boucler le circuit
        }

        _agent.SetDestination(_waypoints[_currentWaypointIndex].position);
    }

    private void ApplyVerticalOscillation()
    {
        float offset = Mathf.Sin(Time.time * _hoverSpeed) * _hoverHeight;
        _agent.baseOffset = _baseOffset + offset;


        Vector3 position = transform.position;
        position.y = _agent.baseOffset;
        transform.position = position;
    }

    public void StopFleeing()
    {
        _isFleeing = false;
        _agent.speed = 2;
    }
}
