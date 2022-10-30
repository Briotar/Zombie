using System;
using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
[RequireComponent(typeof(EnemiesList))]
public class WaveController : MonoBehaviour
{
    [SerializeField] private int _maxEnemiesOnWave = 4;
    [SerializeField] private int _maxBossOnLastWave = 1;
    [SerializeField] private int _increaseCount = 1;
    [SerializeField] private int _maxWaves = 3;

    private EnemySpawner _enemySpawner;
    private EnemiesList _enemiesList;

    private bool _isBoss = false;
    private int _currentWave = 1;
    private int _currentDeadEnemies = 0;

    public event Action<int> NextWave;
    public event Action<int, bool> BossWave;
    public event Action LastWave;
    public event Action<float> EnemiesCountChanged;

    private void OnEnable()
    {
        _enemiesList = GetComponent<EnemiesList>();
        _enemySpawner = GetComponent<EnemySpawner>();
        _isBoss = false;

        _enemiesList.EnemiesCountChanged += () =>
        {
            IncreaseDeadEnemies();
        };
    }

    private void OnDisable()
    {
        _enemiesList.EnemiesCountChanged -= () =>
        {
            IncreaseDeadEnemies();
        };
    }

    private void IncreaseDeadEnemies()
    {
        _currentDeadEnemies++;
        EnemiesCountChanged.Invoke((float)_currentDeadEnemies / _maxEnemiesOnWave);

        if (_currentDeadEnemies >= _maxEnemiesOnWave)
            PrepareStartNextWave();
    }

    private void PrepareStartNextWave()
    {
        _currentWave++;
        ProgressSaver.Instance.SaveWave(_currentWave);

        _currentDeadEnemies = 0;
        _maxEnemiesOnWave += _increaseCount;

        CheckIsThatWaveLast();
    }

    private void CheckIsThatWaveLast()
    {
        if (_currentWave == (_maxWaves + 1))
        {
            LastWave.Invoke();
        }
        else if (_currentWave == _maxWaves)
        {
            _isBoss = true;
            BossWave.Invoke(_currentWave, _isBoss);
        }
        else
        {
            NextWave.Invoke(_currentWave);
        }
    }

    public void StartNextWave()
    {
        if(_isBoss)
        {
            _maxEnemiesOnWave = _maxBossOnLastWave;
            EnemiesCountChanged.Invoke((float)_currentDeadEnemies / _maxEnemiesOnWave);
            _enemySpawner.SetBossWave();
        }
        else
        {
            EnemiesCountChanged.Invoke((float)_currentDeadEnemies / _maxEnemiesOnWave);
            _enemySpawner.StartWave(_maxEnemiesOnWave - _currentDeadEnemies);
        }
    }

    public void StartCurrentWave(int waveNumber)
    {
        _currentWave = waveNumber;

        if (_currentWave == _maxWaves)
        {
            _isBoss = true;
            _maxEnemiesOnWave = 1;
        }
        else
        {
            _maxEnemiesOnWave += _increaseCount * (waveNumber - 1);
        }

        StartNextWave();
    }
}