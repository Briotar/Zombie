using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private Transform _building;

    private bool _isAvailable = true;

    public bool IsAvailable => _isAvailable;

    private void SetAvailability(Enemy enemy)
    {
        _isAvailable = true;

        enemy.Died -= () =>
        {
            SetAvailability(enemy);
        };
    }

    public void SetEnemy(Enemy enemy)
    {
        _isAvailable = false;
        enemy.SetTarget(_building);

        enemy.Died += () =>
        {
            SetAvailability(enemy);
        };
    }
}