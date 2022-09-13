using System.Collections.Generic;
using UnityEngine;

public class RewardsManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private List<Reward> _rewards;
    [SerializeField] private int _maxSpawnedRewards = 3;

    private int _spawnedRewards = 0;

    public static RewardsManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnReward(Transform enemyCenter)
    {
        for (int i = 0; i < _rewards.Count; i++)
        {
            if(_spawnedRewards < _maxSpawnedRewards)
                if(_rewards[i].gameObject.activeInHierarchy == false)
                {
                    _rewards[i].transform.position = enemyCenter.position;
                    _rewards[i].gameObject.SetActive(true);

                    _spawnedRewards++;
                }
        }

        _spawnedRewards = 0;
    }

    public void GetPlayer(Reward reward)
    {
        reward.SetPlayer(_player);
    }
}
