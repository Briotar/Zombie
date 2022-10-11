using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private AttackPointsList _attackPointsList;

    private NavMeshAgent _agent;
    private Rigidbody _rigidbody;
    private Enemy _enemy;
    private Transform _building;
    private Quaternion _lastRotation;

    private bool _isLookAtHouse = false;
    private bool _isDied = false;

    public event Action<Transform> EnemyReachedTarget;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemy = gameObject.GetComponent<Enemy>();
        _agent = GetComponent<NavMeshAgent>();

        EnemiesList.Instance.AddToList(this);

        _agent.enabled = true;
        _agent.destination = _attackPointsList.GetAttackPoint(_enemy);
        _rigidbody.useGravity = true;

        _isDied = false;
    }

    private void FixedUpdate()
    {
        if ((_agent.pathEndPosition - _agent.destination).magnitude <= 0.1f)
            if (_agent.remainingDistance <= 0.01f)
            {
                EnemyReachedTarget.Invoke(_building);
                _agent.enabled = false;

                _isLookAtHouse = true;
            }

        if(_isLookAtHouse)
        {
            Vector3 rotaion = (_building.position - gameObject.transform.position).normalized;
            Vector3 rotaionXZ = new Vector3(rotaion.x, 0f, rotaion.z);

            transform.rotation = Quaternion.LookRotation(rotaionXZ);
        }

        if(_isDied)
        {
            transform.rotation = _lastRotation;
        }
    }

    public void SetTarget(Transform building)
    {
        _building = building;
    }

    public void StartDying()
    {
        _isDied = true;
        _rigidbody.useGravity = false;
        _agent.enabled = false;
        _lastRotation = transform.rotation;

        StopMovement();

        EnemiesList.Instance.RemoveFromList(this);
    }

    public void StopMovement()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    public void MoveUnderGround()
    {
        _rigidbody.velocity = new Vector3(0f, -0.5f, 0f);
    }
}