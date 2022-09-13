using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _rotationLerpSpeed = 0.09f;

    protected void LookAtEnemy(Vector3 target)
    {
        var targetXZ = new Vector3(target.x, 0f, target.z);
        var objectPostionXZ = new Vector3(transform.position.x, 0f, transform.transform.position.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetXZ - objectPostionXZ), _rotationLerpSpeed);
    }

    protected void LookForward(Rigidbody rigidbody)
    {
        var velocityXZ = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocityXZ), _rotationLerpSpeed);
    }
}
