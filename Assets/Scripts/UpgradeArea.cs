using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeArea : MonoBehaviour
{
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private GameObject _effect;
    [SerializeField] private Image _fillImage;
    [SerializeField] private Image _frame;

    private float _startAlphaColor = 0.7f;
    private float _coinsdecreaseSpeed = 0.05f;
    private int _currentUpgradeCost = 15;
    private bool _isCanUpgrade = false;

    public event Action UpgradePanelReady;
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
        UpgradeCostChanged.Invoke(_currentUpgradeCost);
    }

    private void HasPlayerEnoughtCoins(int coins)
    {
        if (_currentUpgradeCost <= coins)
        {
            _isCanUpgrade = true;
            _effect.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isCanUpgrade && other.GetComponent<Player>())
        {
            StartCoroutine(UpgradeCoroutine());
            StartCoroutine(FillImageCoroutine());

            _frame.color = new Color(_frame.color.r, _frame.color.g, _frame.color.b, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _frame.color = new Color(_frame.color.r, _frame.color.g, _frame.color.b, _startAlphaColor);
    }

    private IEnumerator UpgradeCoroutine()
    {
        var coinsSpended = 0;

        while (coinsSpended != _currentUpgradeCost)
        {
            coinsSpended++;
            _playerCollector.DecreaseCoin();

            yield return new WaitForSeconds(_coinsdecreaseSpeed);
        }

        NextUpgrade();
    }

    private IEnumerator FillImageCoroutine()
    {
        var time = _currentUpgradeCost * _coinsdecreaseSpeed;

        while(_fillImage.fillAmount != 1f)
        {
            _fillImage.fillAmount += Time.deltaTime / time;

            yield return new WaitForFixedUpdate();
        }

        _fillImage.fillAmount = 0f;
    }

    private void NextUpgrade()
    {
        _currentUpgradeCost *= 2;

        UpgradePanelReady.Invoke();
        UpgradeCostChanged.Invoke(_currentUpgradeCost);

        _isCanUpgrade = false;
        _effect.SetActive(false);
    }
}
