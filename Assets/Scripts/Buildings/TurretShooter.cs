using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private DefensiveBuilding _turret;
    [SerializeField] private float _distanceToShoot = 3f;
    [SerializeField] private float _shotingSpeed = 0.5f;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bullets;
    [SerializeField] private GameObject _turretTop;

    private Transform _target;
    private float _currentTimeToShoot = 0f;
    private float _startQuaternionX;

    private void Start()
    {
        _startQuaternionX = _turretTop.transform.eulerAngles.x;
    }

    private void Update()
    {
        if(_turret.IsBuilded)
        {
            _target = EnemiesList.Instance.TryGetNearstEnemy(transform);

            if(_target != null)
            {
                float distance = (_target.position - transform.position).magnitude;

                if (distance <= _distanceToShoot)
                {
                    LookAtEnemy();
                    Shoot();
                }
            }
        }
    }

    private void LookAtEnemy()
    {
        _turretTop.transform.rotation = Quaternion.LookRotation(_target.position - _turretTop.transform.position);
        _turretTop.transform.eulerAngles = new Vector3(_startQuaternionX, _turretTop.transform.eulerAngles.y, _turretTop.transform.eulerAngles.z);
    }

    private void Shoot()
    {
        _currentTimeToShoot += Time.deltaTime;

        if(_currentTimeToShoot >= _shotingSpeed)
        {
            for (int i = 0; i < _bullets.Length; i++)
            {
                if (_bullets[i].gameObject.activeInHierarchy == false)
                {
                    _bullets[i].transform.position = _shootPoint.position;
                    _bullets[i].gameObject.SetActive(true);
                    _bullets[i].Init(_shootPoint.rotation, _damage);

                    break;
                }
            }

            _currentTimeToShoot = 0f;
        }
    }
}