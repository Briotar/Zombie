using UnityEngine;
using TMPro;

[RequireComponent(typeof(UpgradeArea))]
public class UpgradeAreaView : MonoBehaviour
{
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private GameObject _upgradePanel;

    private UpgradeArea _upgradeArea;

    private void OnEnable()
    {
        _upgradeArea = GetComponent<UpgradeArea>();

        _upgradeArea.UpgradePanelReady += () =>
        {
            ShowUpgradePanel();
        };

        _upgradeArea.UpgradeCostChanged += (int newCost) =>
        {
            ShowNewCost(newCost);
        };
    }

    private void OnDisable()
    {
        _upgradeArea.UpgradePanelReady -= () =>
        {
            ShowUpgradePanel();
        };

        _upgradeArea.UpgradeCostChanged -= (int newCost) =>
        {
            ShowNewCost(newCost);
        };
    }

    private void ShowUpgradePanel()
    {
        _upgradePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void ShowNewCost(int newCost)
    {
        _costText.text = newCost.ToString();
    }
}
