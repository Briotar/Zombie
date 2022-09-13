using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Reward : MonoBehaviour
{
    [SerializeField] private float _rotationX = 20f;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _forse = 0.23f;
    [SerializeField] private float _collectDistance = 3f;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private Transform _player;

    private bool _canCollect = false;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        RewardsManager.Instance.GetPlayer(this);

        Vector3 forse = GetRandomVector3();
        _rigidbody.AddForce(forse * _speed, ForceMode.VelocityChange);
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;

        _canCollect = false;
        _collider.isTrigger = true;
    }

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(_rotationX, 0f, 0f);

        if(_canCollect)
        {
            var distance = (gameObject.transform.position - _player.position).magnitude;

            if(distance <= _collectDistance)
            {
                _collider.isTrigger = true;
                var velocity = (_player.position - gameObject.transform.position).normalized * _speed;

                _rigidbody.velocity = velocity;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ground>())
        {
            _canCollect = true;
            _collider.isTrigger = false;
            _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y , 0f);
        } 
        else if(other.GetComponent<Player>())
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>())
        {
            Physics.IgnoreCollision(_collider, collision.collider);
        }
    }

    private Vector3 GetRandomVector3()
    {
        var x = Random.Range(-_forse, _forse);
        var z = Random.Range(-_forse, _forse);

        return new Vector3(x, 1f, z);
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }
}
