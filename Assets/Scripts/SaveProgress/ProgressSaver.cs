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
    private int _shootingSpeedIncrease = 0;

    public static ProgressSaver Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SaveLevel(int level)
    {
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

    public void SaveWeaponUpgrade(int damageIncrease, int shootingSpeedIncrease)
    {
        _damageIncrease = damageIncrease;
        _shootingSpeedIncrease = shootingSpeedIncrease;

        PlayerPrefs.SetInt("_damageIncrease", _damageIncrease);
        PlayerPrefs.SetInt("_shootingSpeedIncrease", _shootingSpeedIncrease);
        PlayerPrefs.Save();
    }

    public void SaveMoney(int whiteMoney, int redMoney)
    {
        _whiteMoney = whiteMoney;
        _redMoney = redMoney;

        PlayerPrefs.SetInt("_whiteMoney", _whiteMoney);
        PlayerPrefs.SetInt("_redMoney", _redMoney);
        PlayerPrefs.Save();
    }

    public void SaveDrone()
    {
        _currentDrone = "drone";

        PlayerPrefs.SetString("_currentDrone", _currentDrone);
        PlayerPrefs.Save();
    }
}