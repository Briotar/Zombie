using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyCenter;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Canvas _canvas;

    [SerializeField] private ParticleSystem _hitBlood;
    [SerializeField] private ParticleSystem _hit;
    [SerializeField] private ParticleSystem _dying;

    private float _currentHealth;
    private Animator _animator;
    private EnemyMover _mover;
    private Collider _collider;

    public event Action Died;
    public event Action<float> HealthChanged;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<EnemyMover>();
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet;

        if(bullet = other.GetComponent<Bullet>())
        {
            ApplyDamage(bullet.Damage);

            _hitBlood.Play();
            _hit.Play();
        }
    }

    private void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth / _maxHealth);

        if (_currentHealth <= 0)
        {
            PrepareToDie();
            Died.Invoke();
        }
        else
        {
            _animator.Play(AnimatorEnemyController.States.Hit);
        }
    }

    private void PrepareToDie()
    {
        _dying.Play();
        _mover.StopMovement();
        _collider.enabled = false;
        _canvas.gameObject.SetActive(false);

        RewardsManager.Instance.SpawnReward(_enemyCenter);

        _animator.SetBool(AnimatorEnemyController.Params.IsDying, true);
    }

    private IEnumerator DyingCoroutine()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }

    public void OnDied()
    {
        _mover.MoveUnderGround();

        StartCoroutine(DyingCoroutine());
    }
}
