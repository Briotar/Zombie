using System.Collections;
using UnityEngine;

public class UpgradeButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private PlayerGun _playerGun;
    [SerializeField] private PlayerEffects _effect;
    [SerializeField] private float _secondsBeforeStop = 0.55f;
    [SerializeField] private PlayerWeaponChooser _weaponChooser;
    [SerializeField] private GameObject _drone;

    private Animator[] _objectsOnPanel;

    private void OnEnable()
    {
        _objectsOnPanel = GetComponentsInChildren<Animator>();

        StartCoroutine(PlayButtonsAnimCoroutine(true));
        StartCoroutine(SetTimeScale(_secondsBeforeStop));
    }

    private IEnumerator PlayButtonsAnimCoroutine(bool isAnimatorActive)
    {        
        for (int i = 0; i < _objectsOnPanel.Length; i++)
        {
            if (isAnimatorActive)
                _objectsOnPanel[i].SetBool(AnimatorUpgradePanelController.Params.IsActive, true);
            else
                _objectsOnPanel[i].SetBool(AnimatorUpgradePanelController.Params.IsActive, false);

            yield return new WaitForSeconds(0.1f);
        }

        _upgradePanel.SetActive(isAnimatorActive);
    }

    private IEnumerator SetTimeScale(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 0;
    }

    private void OnButtonClick()
    {
        StartCoroutine(PlayButtonsAnimCoroutine(false));

        Time.timeScale = 1;
        _effect.PlayUpgradeEffect();
    }

    public void OnIncreaseShootingSpeed()
    {
        OnButtonClick();

        _playerGun.IncreaseShootingSpeed();
    }

    public void OnIncreaseDamage()
    {
        OnButtonClick();

        _playerGun.IncreaseDamage();
    }

    public void OnBuyNewWeapon()
    {
        OnButtonClick();

        _weaponChooser.SetNewWeapon();
    }

    public void OnBuyDrone()
    {
        OnButtonClick();

        _drone.SetActive(true);
    }
}