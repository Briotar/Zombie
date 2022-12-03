using UnityEngine;
using TMPro;

public class RewardView : MonoBehaviour
{
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private TMP_Text _whiteCoinsCount;
    [SerializeField] private TMP_Text _redCoinsCount;

    private void OnEnable()
    {
        _playerCollector.WhiteCoinsCountChanged += (int count) =>
        {
            ShowWhiteCoinsCount(count);
        };

        _playerCollector.RedCoinsCountChanged += (int count) =>
        {
            ShowRedCoinsCount(count);
        };
    }

    private void OnDisable()
    {
        _playerCollector.WhiteCoinsCountChanged -= (int count) =>
        {
            ShowWhiteCoinsCount(count);
        };

        _playerCollector.RedCoinsCountChanged -= (int count) =>
        {
            ShowRedCoinsCount(count);
        };
    }

    private void ShowWhiteCoinsCount(int count)
    {
        _whiteCoinsCount.text = count.ToString();
    }

    private void ShowRedCoinsCount(int count)
    {
        _redCoinsCount.text = count.ToString();
    }
}