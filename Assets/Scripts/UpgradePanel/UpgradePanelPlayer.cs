using System;

public class UpgradePanelPlayer : UpgradePanel
{
    private int _upgradesCount = 1;

    public event Action FirstUpgradePanel;
    public event Action SecondUpgradePanel;

    protected override void NextUpgrade()
    {
        ChangeUpgradeCost();

        if (_upgradesCount == 1)
            FirstUpgradePanel.Invoke();
        else 
            SecondUpgradePanel.Invoke();

        _upgradesCount++;
    }
}