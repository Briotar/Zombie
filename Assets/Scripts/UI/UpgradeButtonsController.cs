using UnityEngine;

public class UpgradeButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private Gun _playerGun;

    public void OnIncreaseShootingSpeed()
    {
        _upgradePanel.SetActive(false);
        _playerGun.IncreaseShootingSpeed();

        Time.timeScale = 1;
    }
}
