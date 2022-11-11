using UnityEngine;

public class PlayerStunner : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerGun _gun;

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Enemy>())
        {
            _gun.enabled = false;
            _animator.SetBool(AnimatorPlayerController.Params.IsRunning, true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _gun.enabled = true;
        _animator.SetBool(AnimatorPlayerController.Params.IsRunning, false);
    }
}