using UnityEngine;

public class EnemyAnimationsEventHandler : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyAttacker _enemyAttacker;

    public void OnDied()
    {
        _enemy.OnDied();
    }

    public void OnAttack()
    {
        _enemyAttacker.Attack();
    }
}
