using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitBlood;
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private ParticleSystem _dying;
    [SerializeField] private ParticleSystem _text25;
    [SerializeField] private ParticleSystem _text8;
    [SerializeField] private ParticleSystem _explosion;

    private Vector3 _diedPosition;
    private Vector3 _startPostion;
    private bool _isDying = false;

    private void OnEnable()
    {
        _dying.transform.localPosition = _startPostion;
        _isDying = false;
    }

    private void Update()
    {
        if (_isDying)
            _dying.transform.position = _diedPosition;
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
        _startPostion = _dying.transform.localPosition;
        _diedPosition = _dying.transform.position;
        _isDying = true;
        _dying.Play();
    }
}