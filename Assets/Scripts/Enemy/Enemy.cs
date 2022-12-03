using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyEffects))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyCenter;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Animator _animatorCanvas;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isBoss = false;

    private float _minPlayerDamage = 25;
    private float _currentHealth;
    private Collider _collider;
    private EnemyEffects _effects;
    private EnemyAttacker _attacker;

    public event Action Died;
    public event Action<float> HealthChanged;

    private void OnEnable()
    {
        _collider = GetComponent<Collider>();
        _attacker = GetComponent<EnemyAttacker>();

        _animatorCanvas.enabled = false;
        _currentHealth = _maxHealth;
        _collider.enabled = true;
        _canvas.gameObject.SetActive(true);
    }

    private void Start()
    {
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

        if (_isBoss)
            RewardsManager.Instance.SpawnRedReward(_enemyCenter, 1);
        else
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

    public void ChangeAttackPoint()
    {
        _mover.ChangeAttackPoint();
        _attacker.StopAttack();
    }
}