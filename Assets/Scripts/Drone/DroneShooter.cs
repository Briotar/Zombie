using UnityEngine;

public class DroneShooter : Shooter
{
    [SerializeField] private Transform _player;

    protected override Transform GetTarget()
    {
        return EnemiesList.Instance.TryGetFarthestEnemy(_player);
    }
}
