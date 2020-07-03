using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _playerTransform;

    private enum State
    {
        Idle,
        Patrolling,
        Chasing,
        Hit
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerTransform = GameObject.Find("Player").transform;
        _agent.SetDestination(_playerTransform.position);
    }

    void Update()
    {
        _agent.SetDestination(_playerTransform.position);
    }
}
