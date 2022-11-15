using UnityEngine;

public class PlayerStunner : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerGun _gun;
    [SerializeField] private ParticleSystem _stunEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            _stunEffect.Play();
        }
    }

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
        if (other.GetComponent<Enemy>())
        {
            _gun.enabled = true;
            _stunEffect.Stop();
            _animator.SetBool(AnimatorPlayerController.Params.IsRunning, false);
        }
    }
}