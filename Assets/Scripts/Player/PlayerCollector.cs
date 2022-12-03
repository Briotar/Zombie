using System;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collectEffect;

    private int _currentWhiteCountCoins = 0;
    private int _currentRedCountCoins = 0;

    public event Action<int> WhiteCoinsCountChanged;
    public event Action<int> RedCoinsCountChanged;

    private void Start()
    {
        WhiteCoinsCountChanged.Invoke(_currentWhiteCountCoins);
        RedCoinsCountChanged.Invoke(_currentRedCountCoins);
    }

    private void OnTriggerEnter(Collider other)
    {
        Reward reward;

        if (reward = other.GetComponent<Reward>())
        {
            _collectEffect.Play();

            if(reward.IsRedCoin)
            {
                _currentRedCountCoins++;
                RedCoinsCountChanged.Invoke(_currentRedCountCoins);
            }
            else
            {
                _currentWhiteCountCoins++;
                WhiteCoinsCountChanged.Invoke(_currentWhiteCountCoins);
            }

            ProgressSaver.Instance.SaveWhiteMoney(_currentWhiteCountCoins);
            ProgressSaver.Instance.SaveRedMoney(_currentRedCountCoins);
        }
    }

    public void DecreaseWhiteCoin(int count)
    {
        _currentWhiteCountCoins -= count;
        WhiteCoinsCountChanged.Invoke(_currentWhiteCountCoins);

        ProgressSaver.Instance.SaveWhiteMoney(_currentWhiteCountCoins);
    }

    public void DecreaseRedCoin(int count)
    {
        _currentRedCountCoins -= count;
        RedCoinsCountChanged.Invoke(_currentRedCountCoins);

        ProgressSaver.Instance.SaveRedMoney(_currentRedCountCoins);
    }

    public void SetWhiteMoneyCount(int count)
    {
        _currentWhiteCountCoins = count;
        WhiteCoinsCountChanged.Invoke(_currentWhiteCountCoins);
    }

    public void SetRedMoneyCount(int count)
    {
        _currentRedCountCoins = count;
        RedCoinsCountChanged.Invoke(_currentRedCountCoins);
    }

    public void IncreaseWhiteCoins(int count)
    {
        _currentWhiteCountCoins += count;
        WhiteCoinsCountChanged.Invoke(_currentWhiteCountCoins);

        ProgressSaver.Instance.SaveWhiteMoney(_currentWhiteCountCoins);
    }
}