using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitBlood;
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private ParticleSystem _dying;

    private Vector3 _startPosition;
    private bool _isDying = false;

    private void Update()
    {
        if (_isDying)
            _dying.transform.position = _startPosition;
    }

    public void PlayHitEffetcs()
    {
        _hitBlood.Play();
        _hit.Play();
    }

    public void PLayDeathEffect()
    {
        _startPosition = _dying.transform.position;
        _isDying = true;
        _dying.Play();
    }
}
