using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    
    private Transform _target;
    private Rigidbody _rigidbody;

    private bool _isAlive = true;
    private Vector3 _lastTargetPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        EnemiesList.Instance.AddToList(this);
    }

    private void FixedUpdate()
    {
        if(_isAlive)
        {
            _rigidbody.velocity = (_target.position - gameObject.transform.position).normalized * _speed;

            transform.rotation = Quaternion.LookRotation(new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z));
        }
        else
        {
            Vector3 rotaion = (_lastTargetPosition - gameObject.transform.position).normalized;
            Vector3 rotaionXZ = new Vector3(rotaion.x, 0f, rotaion.z);

            transform.rotation = Quaternion.LookRotation(rotaionXZ);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void StopMovement()
    {
        _isAlive = false;
        _lastTargetPosition = _target.position;
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;

        EnemiesList.Instance.RemoveFromList(this);
    }

    public void MoveUnderGround()
    {
        _rigidbody.velocity = new Vector3(0f, -0.5f, 0f);
    }
}
