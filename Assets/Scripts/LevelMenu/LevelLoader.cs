using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private WaveController _waveController;
    [SerializeField] private WaveView _waveView;
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private PlayerWeaponChooser _weaponChooser;
    [SerializeField] private int _defaultValue = -1;
    [SerializeField] private string _defaultValueString = "none";

    private void Start()
    {
        PlayerPrefs.SetInt("_currentWaveOnlevel", 1);
        PlayerPrefs.SetInt("_whiteMoney", 9999);
        PlayerPrefs.SetInt("_redMoney", 9999);
        PlayerPrefs.Save();

        LoadWave();
        LoadMoney();
        LoadWeapon();
    }

    private void LoadWave()
    {
        int waveNumber = PlayerPrefs.GetInt("_currentWaveOnlevel", _defaultValue);

        if (waveNumber == _defaultValue)
        {
            _waveController.StartCurrentWave(1);
        }
        else
        {
            _waveController.StartCurrentWave(waveNumber);
            _waveView.ShowWaveNumber(waveNumber);
        }
    }

    private void LoadMoney()
    {
        int whiteMoney = PlayerPrefs.GetInt("_whiteMoney" , _defaultValue);
        int redMoney = PlayerPrefs.GetInt("_redMoney", _defaultValue);
        
        if(whiteMoney == _defaultValue)
        {
            _playerCollector.SetWhiteMoneyCount(0);
        }
        else
        {
            _playerCollector.SetWhiteMoneyCount(whiteMoney);
        }

        if (redMoney == _defaultValue)
        {
            _playerCollector.SetRedMoneyCount(0);
        }
        else
        {
            _playerCollector.SetRedMoneyCount(redMoney);
        }
    }

    private void LoadWeapon()
    {
        string weapon = PlayerPrefs.GetString("_currentWeapon", _defaultValueString);

        if(weapon != _defaultValueString)
        {
            _weaponChooser.SetCurrentWeapon(weapon);
        }
    }
}