using System;
using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
[RequireComponent(typeof(EnemiesList))]
public class WaveController : MonoBehaviour
{
    [SerializeField] private int _maxEnemiesOnWave = 10;

    private EnemySpawner _enemySpawner;
    private EnemiesList _enemiesList;

    private int _currentWave = 1;
    private int _currentDeadEnemies = 0;

    public event Action<int> NextWave;
    public event Action<float> EnemiesCountChanged;

    private void OnEnable()
    {
        _enemiesList = GetComponent<EnemiesList>();

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

    private void Start()
    {
        _enemySpawner = GetComponent<EnemySpawner>();

        EnemiesCountChanged.Invoke((float)_currentDeadEnemies / _maxEnemiesOnWave);
        _enemySpawner.StartWave(_maxEnemiesOnWave);
    }

    private void IncreaseDeadEnemies()
    {
        _currentDeadEnemies++;
        EnemiesCountChanged.Invoke((float)_currentDeadEnemies / _maxEnemiesOnWave);

        if (_currentDeadEnemies >= _maxEnemiesOnWave)
            StartNextWave();
    }

    private void StartNextWave()
    {
        _currentWave++;
        NextWave.Invoke(_currentWave);
    }
}
