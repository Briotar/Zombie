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
    [SerializeField] private GameObject _levelCompletePanel;
    [SerializeField] private TMP_Text _nextWaveNumber;

    private int _currentWave;

    private void OnEnable()
    {
        _waveController.NextWave += (int wave) =>
        {
            StartNextWave(wave);
        };

        _waveController.LastWave += () =>
        {
            StartLastWave();
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

        _waveController.LastWave -= () =>
        {
            StartLastWave();
        };

        _waveController.EnemiesCountChanged -= (float sliderValue) =>
        {
            ChangeSliderValue(sliderValue);
        };
    }

    private void StartNextWave(int wave)
    {
        _currentWave = wave;

        _allWavesText.text = $"{_currentWave}";
        _currentWaveText.text = $"INCOMING...";
        _nextWaveNumber.text = $"WAVE {wave}";
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

        _currentWaveText.text = $"WAVE {_currentWave}";
    }

    private void StartLastWave()
    {
        _levelCompletePanel.SetActive(true);
    }
}