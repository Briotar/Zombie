using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnPointsList _spawnPointList;
    [SerializeField] private Enemy[] _enemies;

    [SerializeField] private float _timeToSpawnEmemies = 3f;
    [SerializeField] private int _maxEnemiesOnSpawn = 4;
    [SerializeField] private int _minEnemiesOnSpawn = 2;

    private int _maxEnemiesOnWave;
    private int _spawnedEnemiesCount = 0;
    private float _currentTime;
    private bool _isCanSpawn = true;

    private int _spawnCounter = 0;

    private void Start()
    {
        _currentTime = _timeToSpawnEmemies;
    }

    private void Update()
    {
        if(_isCanSpawn)
            if (_currentTime >= _timeToSpawnEmemies)
            {
                SpawnEnemies();
                _currentTime = 0;
            }
            else
            {
                _currentTime += Time.deltaTime;
            }
    }

    private void SpawnEnemies()
    {
        int currentEnemyCount = 0;
        System.Random rand = new System.Random();

        int maxEnemyCountSpawn = rand.Next(_minEnemiesOnSpawn, _maxEnemiesOnSpawn + 1);
        Vector3 spawnPoint = _spawnPointList.GetSpawnPoint();

        for (int i = 0; i < _enemies.Length; i++)
        {
            if(_spawnedEnemiesCount < _maxEnemiesOnWave)
            {
                if(currentEnemyCount < maxEnemyCountSpawn)
                    if (_enemies[i].gameObject.activeInHierarchy == false)
                    {
                        currentEnemyCount++;

                        _enemies[i].transform.position = spawnPoint;
                        _enemies[i].gameObject.SetActive(true);

                        _spawnedEnemiesCount++;
                    }   
            }
            else
            {
                _isCanSpawn = false;
            }
        }

        _spawnCounter++;
    }

    public void StartWave(int maxEnemiesOnWave)
    {
        _maxEnemiesOnWave = maxEnemiesOnWave;
        _spawnedEnemiesCount = 0;
        _isCanSpawn = true;
    }
}