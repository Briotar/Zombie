using UnityEngine;

public class UpgradePanelBuildings : UpgradePanel
{
    [SerializeField] private DefensiveBuilding _building;

    protected override void NextUpgrade()
    {
        gameObject.SetActive(false);
        _building.Build();
    }
}