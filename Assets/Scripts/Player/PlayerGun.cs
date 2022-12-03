using UnityEngine;

public class PlayerGun : Gun
{
    [SerializeField] private float _damage;
    [SerializeField] private float _damageIncrease;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bullets;
    [SerializeField] private PlayerAnimationsController _animationsController;
    [SerializeField] private ParticleSystem _shotEffect;

    protected override void Shot()
    {
        for (int i = 0; i < _bullets.Length; i++)
        {
            if (_bullets[i].gameObject.activeInHierarchy == false)
            {
                _bullets[i].transform.position = _shootPoint.position;
                _bullets[i].gameObject.SetActive(true);
                _bullets[i].Init(gameObject.transform.rotation, _damage);

                _animationsController.PlayShootAnimation();

                break;
            }
        }

        _shotEffect.Play();
    }

    public void SetShootPoint(Transform newShootPoint, ParticleSystem newShotEffect)
    {
        _shootPoint = newShootPoint;
        _shotEffect = newShotEffect;
    }

    public void IncreaseDamage()
    {
        _damage += _damageIncrease;

        ProgressSaver.Instance.SaveDamage((int)_damage);
    }

    public void LoadDamageUpgrade(int damage)
    {
        _damage = damage;
    }
}