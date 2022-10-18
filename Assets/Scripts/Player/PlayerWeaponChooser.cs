using UnityEngine;

public class PlayerWeaponChooser : MonoBehaviour
{
    [SerializeField] private PlayerAnimationsController _animationsController;
    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _shotGun;
    [SerializeField] private GameObject _rifle;

    private bool _isShotgun = false;
    private bool _isRifle = false;

    public void SetNewWeapon()
    {
        if (_isShotgun == false)
            SetSgotgun();
        else if (_isRifle == false)
            SetRifle();
    }

    public void SetSgotgun()
    {
        _isShotgun = true;

        _pistol.SetActive(false);
        _shotGun.SetActive(true);

        _animationsController.SetShotgun();
    }

    public void SetRifle()
    {
        _isRifle = true;

        _shotGun.SetActive(false);
        _rifle.SetActive(true);

        _animationsController.SetRifle();
    }
}