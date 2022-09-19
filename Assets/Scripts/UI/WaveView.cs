using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WaveView : MonoBehaviour
{
    [SerializeField] private WaveController _waveController;
    [SerializeField] private TMP_Text _allWavesText;
    [SerializeField] private TMP_Text _currentWaveText;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _endWaveText;

    private void OnEnable()
    {
        _waveController.NextWave += (int wave) =>
        {
            StartNextWave(wave);
        };

        _waveController.EnemiesCountChanged += (float sliderValue) =>
        {
            ChangeSliderValue(sliderValue);
        };
    }

    private void OnDisable()
    {
        _waveController.NextWave -= (int wave) =>
        {
            StartNextWave(wave);
        };

        _waveController.EnemiesCountChanged -= (float sliderValue) =>
        {
            ChangeSliderValue(sliderValue);
        };
    }

    private void StartNextWave(int wave)
    {
        _allWavesText.text = $"{wave}";
        _currentWaveText.text = $"INCOMING...";
        _endWaveText.SetActive(true);

        StartCoroutine(SliderCoroutine());
    }

    private void ChangeSliderValue(float value)
    {
        _slider.value = value;
    }

    private IEnumerator SliderCoroutine()
    {
        while(_slider.value != 0)
        {
            yield return new WaitForFixedUpdate();

            _slider.value -= Time.deltaTime / 10f;
        }
    }
}
