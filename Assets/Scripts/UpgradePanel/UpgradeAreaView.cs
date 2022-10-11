using UnityEngine;
using TMPro;

[RequireComponent(typeof(UpgradePanelPlayer))]
public class UpgradeAreaView : MonoBehaviour
{
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private GameObject _firstUpgradePanel;
    [SerializeField] private GameObject _secondUpgradePanel;

    private UpgradePanelPlayer _upgradeArea;

    private void OnEnable()
    {
        _upgradeArea = GetComponent<UpgradePanelPlayer>();

        _upgradeArea.FirstUpgradePanel += () =>
        {
            ShowUpgradePanel(_firstUpgradePanel);
        };

        _upgradeArea.SecondUpgradePanel += () =>
        {
            ShowUpgradePanel(_secondUpgradePanel);
        };

        _upgradeArea.UpgradeCostChanged += (int newCost) =>
        {
            ShowNewCost(newCost);
        };
    }

    private void OnDisable()
    {
        _upgradeArea.FirstUpgradePanel -= () =>
        {
            ShowUpgradePanel(_firstUpgradePanel);
        };

        _upgradeArea.SecondUpgradePanel -= () =>
        {
            ShowUpgradePanel(_secondUpgradePanel);
        };

        _upgradeArea.UpgradeCostChanged -= (int newCost) =>
        {
            ShowNewCost(newCost);
        };
    }

    private void ShowUpgradePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    private void ShowNewCost(int newCost)
    {
        _costText.text = newCost.ToString();
    }
}