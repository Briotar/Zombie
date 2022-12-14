using System;

public class UpgradePanelPlayer : UpgradePanel
{
    public event Action UpgadePurchased;

    protected override void NextUpgrade()
    {
        UpgadePurchased.Invoke();

        ChangeUpgradeCost();
    }
}