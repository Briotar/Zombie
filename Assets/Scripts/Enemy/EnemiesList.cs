using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private List<EnemyMover> _enemies = new List<EnemyMover>();
    private EnemyMover _nearstEnemyToPlayer;

    public static EnemiesList Instance;

    public event Action EnemiesCountChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TryFindNearstEnemy(_player);
    }

    private void ShowList()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            Debug.Log(_enemies[i].gameObject.name);
        }
    }

    private void TryFindNearstEnemy(Transform player)
    {
        if(_enemies.Count != 0)
        {
            _nearstEnemyToPlayer = _enemies[0];
            var nearstEnemyDistance = (_enemies[0].transform.position - player.position).magnitude;

            for (int i = 0; i < _enemies.Count; i++)
            {
                var fromEnemyToPlayer = (_enemies[i].transform.position - player.position).magnitude;

                if (fromEnemyToPlayer <= nearstEnemyDistance)
                {
                    _nearstEnemyToPlayer = _enemies[i];
                    nearstEnemyDistance = fromEnemyToPlayer;
                }
            }
        }
        else
        {
            _nearstEnemyToPlayer = null;
        }
    }

    public Transform TryGetNearstEnemy(Transform player)
    {
        TryFindNearstEnemy(player);

        if (_nearstEnemyToPlayer != null)
            return _nearstEnemyToPlayer.transform;
        else
            return null;
    }

    public void AddToList(EnemyMover enemy)
    {
        _enemies.Add(enemy);
        enemy.SetTarget(_player);
    }

    public void RemoveFromList(EnemyMover enemy)
    {
        _enemies.Remove(enemy);

        EnemiesCountChanged.Invoke();
    }
}
