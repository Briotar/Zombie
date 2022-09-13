using UnityEngine;

public class DroneGun : Gun
{
    [SerializeField] private float _damage;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bullets;

    protected override void Shot()
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
    }
}
