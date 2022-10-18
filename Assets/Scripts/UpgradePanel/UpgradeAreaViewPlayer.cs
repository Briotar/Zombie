using UnityEngine;

public class UpgradeAreaViewPlayer : UpgradeAreaView
{
    [SerializeField] private GameObject _firstUpgradePanel;
    [SerializeField] private GameObject _secondUpgradePanel;

    private UpgradePanelPlayer _upgradeAreaPlayer;

    protected void OnEnable()
    {
        base.OnEnable();

        _upgradeAreaPlayer = GetComponent<UpgradePanelPlayer>();

        _upgradeAreaPlayer.FirstUpgradePanel += () =>
        {
            ShowUpgradePanel(_firstUpgradePanel);
        };

        _upgradeAreaPlayer.SecondUpgradePanel += () =>
        {
            ShowUpgradePanel(_secondUpgradePanel);
        };
    }

    private void ShowUpgradePanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}