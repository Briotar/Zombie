using UnityEngine;
using UnityEngine.UI;

public class HouseView : MonoBehaviour
{
    [SerializeField] private House _house;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _house.HealthChanged += (float health) =>
        {
            ShowHealth(health);
        };
    }

    private void OnDisable()
    {
        _house.HealthChanged -= (float health) =>
        {
            ShowHealth(health);
        };
    }

    private void ShowHealth(float health)
    {
        _slider.value = health;
    }
}