using System;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;

    public event Action<float> HealthChanged;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged.Invoke(_currentHealth / _maxHealth);

        Debug.Log(_currentHealth);
    }

    protected virtual void Destroy()
    {

    }

    public void Applydamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth / _maxHealth);

        if (_currentHealth <= 0)
        {
            Destroy();
        }
    }
}