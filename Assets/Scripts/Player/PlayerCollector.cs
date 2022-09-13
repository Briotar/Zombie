using System;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private int _currentCountCoins = 0;

    public event Action<int> CoinsCountChanged;

    private void Start()
    {
        CoinsCountChanged.Invoke(_currentCountCoins);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Reward>())
        {
            _currentCountCoins++;
            CoinsCountChanged.Invoke(_currentCountCoins);
        }
    }

    public void DecreaseCoin()
    {
        _currentCountCoins--;
        CoinsCountChanged.Invoke(_currentCountCoins);
    }
}
