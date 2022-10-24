using UnityEngine;

public class ShootPointSetter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private PlayerGun _gun;

    private void OnEnable()
    {
        _gun.SetShootPoint(_shootPoint, _shotEffect);
    }
}