using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
    [SerializeField] private Transform _house;
    [SerializeField] private Transform _player;

    private List<EnemyMover> _enemies = new List<EnemyMover>();
    private EnemyMover _nearstEnemyToPlayer;
    private EnemyMover _farthestEnemyToPlayer;

    public static EnemiesList Instance;

    public event Action EnemiesCountChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TryFindNearstandFarthestEnemy(_player);
    }

    private void ShowList()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            Debug.Log(_enemies[i].gameObject.name);
        }
    }

    private void TryFindNearstandFarthestEnemy(Transform player)
    {
        if(_enemies.Count != 0)
        {
            _nearstEnemyToPlayer = _enemies[0];
            var nearstEnemyDistance = (_enemies[0].transform.position - player.position).magnitude;
            var farthestEnemyDistance = (_enemies[0].transform.position - player.position).magnitude;

            for (int i = 0; i < _enemies.Count; i++)
            {
                var fromEnemyToPlayer = (_enemies[i].transform.position - player.position).magnitude;

                if (fromEnemyToPlayer <= nearstEnemyDistance)
                {
                    _nearstEnemyToPlayer = _enemies[i];
                    nearstEnemyDistance = fromEnemyToPlayer;
                }

                if(fromEnemyToPlayer >= farthestEnemyDistance)
                {
                    _farthestEnemyToPlayer = _enemies[i];
                    farthestEnemyDistance = fromEnemyToPlayer;
                }
            }
        }
        else
        {
            _nearstEnemyToPlayer = null;
            _farthestEnemyToPlayer = null;
        }
    }

    public Transform TryGetNearstEnemy(Transform player)
    {
        TryFindNearstandFarthestEnemy(player);

        if (_nearstEnemyToPlayer != null)
            return _nearstEnemyToPlayer.transform;
        else
            return null;
    }

    public Transform TryGetFarthestEnemy(Transform player)
    {
        TryFindNearstandFarthestEnemy(player);

        if (_farthestEnemyToPlayer != null)
            return _farthestEnemyToPlayer.transform;
        else
            return null;
    }

    public void AddToList(EnemyMover enemy)
    {
        _enemies.Add(enemy);
        //enemy.SetTarget(_house);
    }

    public void RemoveFromList(EnemyMover enemy)
    {
        _enemies.Remove(enemy);

        EnemiesCountChanged.Invoke();
    }
}