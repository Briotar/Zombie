using UnityEngine;

public class UpgradePanelBuildings : UpgradePanel
{
    [SerializeField] private DefensiveBuilding _building;
    [SerializeField] private int _cost;

    protected override int SetCost(bool isWhiteCoin = false)
    {
        return _cost;
    }

    protected override void NextUpgrade()
    {
        gameObject.SetActive(false);
        _building.Build();
    }
}