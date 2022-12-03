using UnityEngine;

public class UpgradeAreaViewPlayer : UpgradeAreaView
{
    [SerializeField] private GameObject _upgradePanel;

    private UpgradePanelPlayer _upgradeAreaPlayer;

    protected void OnEnable()
    {
        base.OnEnable();

        _upgradeAreaPlayer = GetComponent<UpgradePanelPlayer>();

        _upgradeAreaPlayer.UpgadePurchased += () =>
        {
            ShowUpgradePanel();
        };
    }

    private void ShowUpgradePanel()
    {
        _upgradePanel.SetActive(true);
    }
}