using UnityEngine;

[RequireComponent(typeof(Gun))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private float _shootDistance = 5f;

    private Gun _gun;
    private Transform _target;
    private bool _isShoot = false;

    public bool IsShoot => _isShoot;
    public Vector3 TargetPosition { get; private set; }

    private void Start()
    {
        _gun = GetComponent<Gun>();

        TargetPosition = Vector3.zero;
    }

    private void Update()
    {
        _target = GetTarget();

        if (_target != null)
        {
            TargetPosition = _target.position;
            var distance = (_target.position - transform.position).magnitude;

            if(distance <= _shootDistance)
            {
                _isShoot = true;

                SetIsGunCanShot();
            }
            else
            {
                _isShoot = false;

                SetIsGunCanShot();
            }
        }
        else
        {
            TargetPosition = Vector3.zero;
            _isShoot = false;

            SetIsGunCanShot();
        }
    }

    private void SetIsGunCanShot()
    {
        _gun.SetIsCanShot(_isShoot);
    }
    
    protected virtual Transform GetTarget()
    {
        return EnemiesList.Instance.TryGetNearstEnemy(this.transform);
    }
}
