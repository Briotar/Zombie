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
    [SerializeField] private bool _isNeedRedCoin = false;
    [SerializeField] private float _timeToUpgrade = 1f;
    [SerializeField] private bool _isRedCoins;

    private float _startAlphaColor = 0.7f;

    private bool _isCanUpgrade = false;
    private bool _isPlayerStay = false;

    public event Action<int> UpgradeCostChanged;

    private void OnEnable()
    {
        if(_isNeedRedCoin)
        {
            _playerCollector.RedCoinsCountChanged += (int coins) =>
            {
                HasPlayerEnoughtCoins(coins);
            };

            _currentUpgradeCost = SetCost(false);
        }
        else
        {
            _playerCollector.WhiteCoinsCountChanged += (int coins) =>
            {
                HasPlayerEnoughtCoins(coins);
            };

            _currentUpgradeCost = SetCost(true);
        }
    }

    private void OnDisable()
    {
        if (_isNeedRedCoin)
        {
            _playerCollector.RedCoinsCountChanged += (int coins) =>
            {
                HasPlayerEnoughtCoins(coins);
            };
        }
        else
        {
            _playerCollector.WhiteCoinsCountChanged += (int coins) =>
            {
                HasPlayerEnoughtCoins(coins);
            };
        }
    }

    private void Start()
    {
        UpgradeCostChanged.Invoke(_currentUpgradeCost);
    }

    protected virtual int SetCost(bool isWhiteCoin = false)
    {
        if(isWhiteCoin)
        {
            var cost = PlayerPrefs.GetInt("_upgradeWhiteCoinsCost", -1);

            if (cost != -1)
                return cost;
        }
        else
        {
            var cost = PlayerPrefs.GetInt("_upgradeRedCoinsCost", -1);

            if (cost != -1)
                return cost;
        }

        return _currentUpgradeCost;
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

        StartCoroutine(FillImageCoroutine());
    }

    private IEnumerator FillImageCoroutine()
    {
        var time = _timeToUpgrade;

        while (_fillImage.fillAmount != 1f && _isPlayerStay)
        {
            _fillImage.fillAmount += Time.deltaTime / time;

            yield return new WaitForFixedUpdate();
        }

        if(_fillImage.fillAmount >= 1)
        {
            var cost = _currentUpgradeCost;
            NextUpgrade();

            if (_isNeedRedCoin)
                _playerCollector.DecreaseRedCoin(cost);
            else
                _playerCollector.DecreaseWhiteCoin(cost);
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

        UpgradeCostChanged.Invoke(_currentUpgradeCost);

        if (_isRedCoins)
            ProgressSaver.Instance.SaveUpgradeCostRedCoins(_currentUpgradeCost);
        else
            ProgressSaver.Instance.SaveUpgradeCostWhiteCoins(_currentUpgradeCost);
    }
}