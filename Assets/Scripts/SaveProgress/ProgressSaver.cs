using UnityEngine;

public class ProgressSaver : MonoBehaviour
{
    private int _currentLevel = 1;
    private int _currentWaveOnlevel = 1;
    private int _whiteMoney = 0;
    private int _redMoney = 0;
    private string _currentWeapon = "pistol";
    private string _currentDrone = "none";
    private int _damageIncrease = 0;
    private float _shootingSpeedIncrease = 0;
    private int _upgradeWhiteCoinsCost;
    private int _upgradeRedCoinsCost;
    private int _chestCoinsCount = 5;

    public static ProgressSaver Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SaveLevel(int level)
    {
        if(_currentLevel < level)
            _currentLevel = level;

        PlayerPrefs.SetInt("_currentLevel", _currentLevel);
        PlayerPrefs.Save();
    }

    public void SaveWave(int waveNumber)
    {
        _currentWaveOnlevel = waveNumber;

        PlayerPrefs.SetInt("_currentWaveOnlevel", _currentWaveOnlevel);
        PlayerPrefs.Save();
    }

    public void SaveWeapon(string weapon)
    {
        _currentWeapon = weapon;

        PlayerPrefs.SetString("_currentWeapon", _currentWeapon);
        PlayerPrefs.Save();
    }

    public void SaveDamage(int damageIncrease)
    {
        _damageIncrease = damageIncrease;

        PlayerPrefs.SetInt("_damageIncrease", _damageIncrease);
        PlayerPrefs.Save();
    }

    public void SaveShootingSpeed(float increase)
    {
        _shootingSpeedIncrease = increase;

        PlayerPrefs.SetFloat("_shootingSpeedIncrease", _shootingSpeedIncrease);
        PlayerPrefs.Save();
    }

    public void SaveRedMoney(int redMoney)
    {
        _redMoney = redMoney;

        PlayerPrefs.SetInt("_redMoney", _redMoney);
        PlayerPrefs.Save();
    }

    public void SaveWhiteMoney(int whiteMoney)
    {
        _whiteMoney = whiteMoney;

        PlayerPrefs.SetInt("_whiteMoney", _whiteMoney);
        PlayerPrefs.Save();
    }

    public void SaveDrone()
    {
        _currentDrone = "drone";

        PlayerPrefs.SetString("_currentDrone", _currentDrone);
        PlayerPrefs.Save();
    }

    public void SaveUpgradeCostWhiteCoins(int count)
    {
        _upgradeWhiteCoinsCost = count;

        PlayerPrefs.SetInt("_upgradeWhiteCoinsCost", _upgradeWhiteCoinsCost);
        PlayerPrefs.Save();
    }

    public void SaveUpgradeCostRedCoins(int count)
    {
        _upgradeRedCoinsCost = count;

        PlayerPrefs.SetInt("_upgradeRedCoinsCost", _upgradeRedCoinsCost);
        PlayerPrefs.Save();
    }

    public void SaveChestCoins(int count)
    {
        int coinsCount =  PlayerPrefs.GetInt("_chestCoinCount", -1);

        if (coinsCount > 0)
            _chestCoinsCount = coinsCount;
        else
            _chestCoinsCount = 5;

        _chestCoinsCount += count;
        PlayerPrefs.SetInt("_chestCoinCount", _chestCoinsCount);
    }
}