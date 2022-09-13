using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Slider _slider;

    private void OnEnable()
    {
        _enemy.HealthChanged += (float currentHealth) =>
        {
            ChangeHealth(currentHealth);
        };
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= (float currentHealth) =>
        {
            ChangeHealth(currentHealth);
        };
    }

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();

        _slider.value = _slider.maxValue;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void ChangeHealth(float currentHealth)
    {
        _slider.value = currentHealth;
    }
}
