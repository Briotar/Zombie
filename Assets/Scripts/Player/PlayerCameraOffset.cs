using UnityEngine;

public class PlayerCameraOffset : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _lerpSpeed = 0.002f;

    private float _distanceToEnemy = 2f;
    private Vector3 _startPostion;

    private void Start()
    {
        _startPostion = transform.localPosition;
    }

    private void Update()
    {
        if(_shooter.IsShoot)
        {
            var offsetX = (_shooter.TargetPosition.x - _shooter.transform.position.x) / _distanceToEnemy;
            var offsetZ = (_shooter.TargetPosition.z - _shooter.transform.position.z) / _distanceToEnemy;
            var newPosition = new Vector3(_shooter.transform.position.x + offsetX, transform.position.y, _shooter.transform.position.z + offsetZ);

            transform.position = Vector3.MoveTowards(transform.position, newPosition, _lerpSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _startPostion, _lerpSpeed);
        }
    }
}
