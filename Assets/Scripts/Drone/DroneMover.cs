using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Shooter))]
public class DroneMover : Mover
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startDronePosition;

    private Rigidbody _rigidbody;
    private Shooter _shooter;

    private bool _isNeedRotate = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
    }

    private void FixedUpdate()
    {
        var target = _shooter.TargetPosition;

        if(target == Vector3.zero)
        {
            if(_isNeedRotate)
            {
                LookForward(_rigidbody);
            }

            MoveToPlayer();
        }
        else
        {
            LookAtEnemy(target);
            var distance = (_shooter.TargetPosition - transform.position).magnitude;

            if (distance > 1f && _shooter.IsShoot == false)
            {
                MoveToTarget(target);
            }
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        var targetPosition = new Vector3(target.x, transform.position.y, target.z);
        _rigidbody.velocity = (targetPosition - transform.position).normalized * _speed;
    }

    private void MoveToPlayer()
    {
        var targetPosition = new Vector3(_startDronePosition.position.x, transform.position.y, _startDronePosition.position.z);

        if ((targetPosition - transform.position).magnitude <= 0.1f)
        {
            _rigidbody.velocity = Vector3.zero;
            _isNeedRotate = false;
        }
        else
        {
            _rigidbody.velocity = (targetPosition - transform.position).normalized * _speed;
            _isNeedRotate = true;
        }
    }
}
