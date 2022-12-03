using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime = 10f;

    private float _currentLifeTime = 0f;
    private float _damage;
    private Rigidbody _rigidbody;
    private ParticleSystem _bulletEffect;

    public float Damage => _damage;

    private void OnEnable()
    {
        _bulletEffect = GetComponentInChildren<ParticleSystem>();
        _rigidbody = GetComponent<Rigidbody>();
        _currentLifeTime = 0f;
    }

    private void Update()
    {
        if(_currentLifeTime >= _lifeTime)
            gameObject.SetActive(false);
        else
            _currentLifeTime += Time.deltaTime;
    }

    public void Init(Quaternion rotation, float damage)
    {
        gameObject.transform.rotation = rotation;
        _bulletEffect.transform.rotation = rotation;
        _damage = damage;

        _rigidbody.velocity = transform.forward * _bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>())
        {
            gameObject.SetActive(false);
        }
        else if(other.GetComponent<House>())
        {
            gameObject.SetActive(false);
        }
    }
}