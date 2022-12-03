using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _shotCooldown;
    [SerializeField] private float _cooldownDecrease = 0.1f;

    private float _currentTime = 0f;
    private bool _canShot = false;

    private void Update()
    {
        if(_canShot)
            if (_currentTime >= _shotCooldown)
            {
                Shot();

                _currentTime = 0f;
            }
            else
            {
                _currentTime += Time.deltaTime;
            }
    }

    protected virtual void Shot()
    {
    }

    public void SetIsCanShot(bool canFire)
    {
        _canShot = canFire;
    }

    public void IncreaseShootingSpeed()
    {
        _shotCooldown -= _cooldownDecrease;

        if (_shotCooldown <= 0.2f)
            _shotCooldown = 0.2f;

        ProgressSaver.Instance.SaveShootingSpeed(_shotCooldown);
    }

    public void LoadShootingSpeedUpgrade(float shotCooldown)
    {
        _shotCooldown = shotCooldown;

        Debug.Log(_shotCooldown);
    }
}