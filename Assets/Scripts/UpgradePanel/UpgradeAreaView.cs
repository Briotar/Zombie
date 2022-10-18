using UnityEngine;
using TMPro;

[RequireComponent(typeof(UpgradePanel))]
public class UpgradeAreaView : MonoBehaviour
{
    [SerializeField] private TMP_Text _costText;

    private UpgradePanel _upgradeArea;

    protected void OnEnable()
    {
        _upgradeArea = GetComponent<UpgradePanel>();

        _upgradeArea.UpgradeCostChanged += (int newCost) =>
        {
            ShowNewCost(newCost);
        };
    }

    private void OnDisable()
    {
        _upgradeArea.UpgradeCostChanged -= (int newCost) =>
        {
            ShowNewCost(newCost);
        };
    }

    private void ShowNewCost(int newCost)
    {
        _costText.text = newCost.ToString();
    }
}