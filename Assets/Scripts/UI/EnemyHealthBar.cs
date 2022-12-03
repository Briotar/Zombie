using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Image _damageEffect;
    [SerializeField] private float _lerpSpeed = 0.02f;

    private Vector3 _localScale;
    private Quaternion _startRotation;
    private Slider _slider;

    private void OnEnable()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.value = _slider.maxValue;

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

        _slider.transform.localScale = _localScale;
    }

    private void Start()
    {
        _startRotation = transform.rotation;
        _localScale = _slider.transform.localScale;
    }

    private void Update()
    {
        transform.rotation = _startRotation;

        _damageEffect.fillAmount = Mathf.MoveTowards(_damageEffect.fillAmount, _slider.value, _lerpSpeed);
    }

    private void ChangeHealth(float currentHealth)
    {
        _slider.value = currentHealth;
    }
}