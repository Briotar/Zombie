using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitBlood;
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private ParticleSystem _dying;
    [SerializeField] private ParticleSystem _text25;
    [SerializeField] private ParticleSystem _text8;
    [SerializeField] private ParticleSystem _explosion;

    private Vector3 _startPosition;
    private bool _isDying = false;

    private void Update()
    {
        if (_isDying)
            _dying.transform.position = _startPosition;
    }

    public void PlayHitEffetcs(bool isPlayer)
    {
        if (isPlayer)
            _text25.Play();
        else
            _text8.Play();

        _hitBlood.Play();
        _hit.Play();
        _explosion.Play();
    }

    public void PLayDeathEffect()
    {
        _startPosition = _dying.transform.position;
        _isDying = true;
        _dying.Play();
    }
}
