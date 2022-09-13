using UnityEngine;
using TMPro;

public class RewardView : MonoBehaviour
{
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private TMP_Text _rewardsCount;

    private void OnEnable()
    {
        _playerCollector.CoinsCountChanged += (int count) =>
        {
            ShowRewardsCount(count);
        };
    }

    private void OnDisable()
    {
        _playerCollector.CoinsCountChanged -= (int count) =>
        {
            ShowRewardsCount(count);
        };
    }

    private void ShowRewardsCount(int count)
    {
        _rewardsCount.text = count.ToString();
    }
}
