using UnityEngine;

public class UpgradeButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private Gun _playerGun;
    [SerializeField] private PlayerEffects _effect;

    public void OnIncreaseShootingSpeed()
    {
        _upgradePanel.SetActive(false);
        _playerGun.IncreaseShootingSpeed();

        Time.timeScale = 1;

        _effect.PlayUpgradeEffect();
    }
}
