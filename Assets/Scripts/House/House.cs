using System;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;

    public event Action<float> HealthChanged;
    public event Action GameOver;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged.Invoke(_currentHealth / _maxHealth);
    }

    public void Applydamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth / _maxHealth);

        if (_currentHealth <= 0)
        {
            //GameOver.Invoke();
            Debug.Log("Game Over!!!");
        }
    }
}