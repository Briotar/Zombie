using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private Image _fillImage;
    [SerializeField] private Image _frame;
    [SerializeField] private GameObject _effect;
    [SerializeField] private float _delayBeforeUpgrade = 0.3f;
    [SerializeField] private int _currentUpgradeCost = 15;

    private float _startAlphaColor = 0.7f;
    private float _coinsdecreaseSpeed = 0.05f;

    private bool _isCanUpgrade = false;
    private bool _isPlayerStay = false;

    public event Action<int> UpgradeCostChanged;

    private void OnEnable()
    {
        _playerCollector.CoinsCountChanged += (int coins) =>
        {
            HasPlayerEnoughtCoins(coins);
        };
    }

    private void OnDisable()
    {
        _playerCollector.CoinsCountChanged -= (int coins) =>
        {
            HasPlayerEnoughtCoins(coins);
        };
    }

    private void Start()
    {
        //UpgradeCostChanged.Invoke(_currentUpgradeCost);
    }

    private void HasPlayerEnoughtCoins(int coins)
    {
        if (_currentUpgradeCost <= coins)
        {
            _isCanUpgrade = true;
            _effect.SetActive(true);
        }
        else
        {
            _isCanUpgrade = false;
            _effect.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isCanUpgrade && other.GetComponent<Player>())
        {
            StartCoroutine(DelayCoroutine());

            _frame.color = new Color(_frame.color.r, _frame.color.g, _frame.color.b, 1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isCanUpgrade && other.GetComponent<Player>())
        {
            _isPlayerStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isPlayerStay = false;
        _fillImage.fillAmount = 0f;
        _frame.color = new Color(_frame.color.r, _frame.color.g, _frame.color.b, _startAlphaColor);
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(_delayBeforeUpgrade);

        StartCoroutine(UpgradeCoroutine());
        StartCoroutine(FillImageCoroutine());
    }

    private IEnumerator UpgradeCoroutine()
    {
        var coinsSpended = 0;

        while (coinsSpended != _currentUpgradeCost && _isPlayerStay)
        {
            coinsSpended++;

            yield return new WaitForSeconds(_coinsdecreaseSpeed);
        }

        if (coinsSpended == _currentUpgradeCost)
        {
            _playerCollector.DecreaseCoin(coinsSpended);
            NextUpgrade();
        }
    }

    private IEnumerator FillImageCoroutine()
    {
        var time = _currentUpgradeCost * _coinsdecreaseSpeed;

        while (_fillImage.fillAmount != 1f && _isPlayerStay)
        {
            _fillImage.fillAmount += Time.deltaTime / time;

            yield return new WaitForFixedUpdate();
        }

        _fillImage.fillAmount = 0f;
    }

    protected virtual void NextUpgrade()
    {
    }

    protected void ChangeUpgradeCost()
    {
        _currentUpgradeCost *= 2;

        _isCanUpgrade = false;
        _effect.SetActive(false);

        //UpgradeCostChanged.Invoke(_currentUpgradeCost);
    }
}