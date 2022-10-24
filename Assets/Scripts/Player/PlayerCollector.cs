using System;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collectEffect;

    private int _currentCountCoins = 0;

    public event Action<int> CoinsCountChanged;

    private void Start()
    {
        CoinsCountChanged.Invoke(_currentCountCoins);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Reward>())
        {
            _collectEffect.Play();

            _currentCountCoins++;
            CoinsCountChanged.Invoke(_currentCountCoins);

            ProgressSaver.Instance.SaveMoney(_currentCountCoins, 0);
        }
    }

    public void DecreaseCoin(int count)
    {
        _currentCountCoins -= count;
        CoinsCountChanged.Invoke(_currentCountCoins);

        ProgressSaver.Instance.SaveMoney(_currentCountCoins, 0);
    }

    public void SetMoneyCount(int count)
    {
        _currentCountCoins = count;
    }
}