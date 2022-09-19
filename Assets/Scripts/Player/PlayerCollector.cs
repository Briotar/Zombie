using System;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private int _currentCountCoins = 0;
    [SerializeField] private ParticleSystem _collectEffect;

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
        }
    }

    public void DecreaseCoin()
    {
        _currentCountCoins--;
        CoinsCountChanged.Invoke(_currentCountCoins);
    }
}
