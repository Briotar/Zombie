using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Shooter))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _rotationLerpSpeed = 0.09f;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Shooter _shooter;

    private float _minVelocity = 0.001f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigidbody.velocity.y, _joystick.Vertical * _speed);

        if (_shooter.IsShoot)
            LookAtEnemy(_shooter.TargetPosition);

        if(_joystick.Vertical != 0)
            if (_rigidbody.velocity.magnitude > _minVelocity)
            {
                if (_shooter.IsShoot)
                    LookAtEnemy(_shooter.TargetPosition);
                else
                    LookForward();
            }
    }

    private void LookAtEnemy(Vector3 target)
    {
        var targetXZ = new Vector3(target.x, 0f, target.z);
        var objectPostionXZ = new Vector3(transform.position.x, 0f, transform.transform.position.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetXZ - objectPostionXZ), _rotationLerpSpeed);

        Debug.DrawLine(gameObject.transform.position, target, Color.red);
    }

    private void LookForward()
    {
        var velocityXZ = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocityXZ), _rotationLerpSpeed);
    }
}
