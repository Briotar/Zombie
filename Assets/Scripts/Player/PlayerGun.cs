using UnityEngine;

[RequireComponent(typeof(PlayerAnimationsController))]
public class PlayerGun : Gun
{
    [SerializeField] private float _damage;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bullets;

    private PlayerAnimationsController _animationsController;

    private void Start()
    {
        _animationsController = GetComponent<PlayerAnimationsController>();
    }

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
    }

}
