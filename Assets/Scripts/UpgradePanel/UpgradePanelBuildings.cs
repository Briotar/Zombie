using UnityEngine;

public class UpgradePanelBuildings : UpgradePanel
{
    [SerializeField] private Wall _wall;

    protected override void NextUpgrade()
    {
        gameObject.SetActive(false);
        _wall.Build();
    }
}