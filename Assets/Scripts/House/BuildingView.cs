using UnityEngine;
using UnityEngine.UI;

public class BuildingView : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _building.HealthChanged += (float health) =>
        {
            ShowHealth(health);
        };
    }

    private void OnDisable()
    {
        _building.HealthChanged -= (float health) =>
        {
            ShowHealth(health);
        };
    }

    private void ShowHealth(float health)
    {
        _slider.value = health;
    }
}