using UnityEngine;

public class DroneShootPointMover : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;

    private void Update()
    {
        transform.LookAt(_shooter.TargetPosition);
    }
}
