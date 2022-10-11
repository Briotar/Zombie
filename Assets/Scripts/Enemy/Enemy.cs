using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyEffects))]
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyCenter;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Animator _animatorCanvas;

    private float _minPlayerDamage = 25;
    private float _currentHealth;
    private Animator _animator;
    private EnemyMover _mover;
    private Collider _collider;
    private EnemyEffects _effects;

    public event Action Died;
    public event Action<float> HealthChanged;

    private void OnEnable()
    {
        _collider = GetComponent<Collider>();
        _mover = GetComponent<EnemyMover>();

        _animatorCanvas.enabled = false;
        _currentHealth = _maxHealth;
        _collider.enabled = true;
        _canvas.gameObject.SetActive(true);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _effects = GetComponent<EnemyEffects>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet;

        if(bullet = other.GetComponent<Bullet>())
        {
            ApplyDamage(bullet.Damage);
        }
    }

    private void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth / _maxHealth);

        if(damage < _minPlayerDamage)
            _effects.PlayHitEffetcs(false);
        else
            _effects.PlayHitEffetcs(true);

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
        _effects.PLayDeathEffect();
        _mover.StartDying();
        _collider.enabled = false;
        _animatorCanvas.enabled = true;

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

    public void SetTarget(Transform building)
    {
        _mover.SetTarget(building);
    }
}