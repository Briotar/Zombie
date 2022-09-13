using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyReward : MonoBehaviour
{
    [SerializeField] private Transform[] _reward;
    [SerializeField] private Transform _spawnPoint;

    private Enemy _enemy;

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();

        _enemy.Died += () =>
        {
            SpawnRaward();
        };
    }

    private void OnDisable()
    {
        _enemy.Died -= () =>
        {
            SpawnRaward();
        };
    }

    private void SpawnRaward()
    {
        /*for (int i = 0; i < _reward.Length; i++)
        {
            _reward[i].gameObject.SetActive(true);
        }*/
    }
}
