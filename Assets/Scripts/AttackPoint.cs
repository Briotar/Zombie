using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private Transform _building;
    [SerializeField] private Building _Building;

    private bool _isAvailable = true;
    private Enemy _enemy = null;

    public bool IsAvailable => _isAvailable;

    private void OnEnable()
    {
        _Building.Destroyed += () =>
        {
            SetAvailabilityFalse();
        };
    }

    private void OnDisable()
    {
        _Building.Destroyed -= () =>
        {
            SetAvailabilityFalse();
        };
    }

    private void SetAvailability(Enemy enemy)
    {
        _isAvailable = true;

        enemy.Died -= () =>
        {
            SetAvailability(enemy);
        };
    }

    private void SetAvailabilityFalse()
    {
        _isAvailable = false;

        if(_enemy != null)
        {
            _enemy.ChangeAttackPoint();
        }
    }

    public void SetEnemy(Enemy enemy)
    {
        _isAvailable = false;
        _enemy = enemy;
        enemy.SetTarget(_building);

        enemy.Died += () =>
        {
            SetAvailability(enemy);
        };
    }
}