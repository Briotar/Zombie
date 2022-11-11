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

    private int _currentWave = 1;

    public string CurrentWaveString;

    private void OnEnable()
    {
        CurrentWaveString = _currentWave.ToString();

        _waveController.NextWave += (int wave) =>
        {
            StartNextWave(wave);
        };

        _waveController.BossWave += (int wave, bool isBoss) =>
        {
            StartNextWave(wave, isBoss);
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

        _waveController.BossWave -= (int wave, bool isBoss) =>
        {
            StartNextWave(wave, isBoss);
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

    private void StartNextWave(int wave, bool isBoss = false)
    {
        _currentWave = wave;
        CurrentWaveString = _currentWave.ToString();

        UpdateWaveNumber();

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

    private void StartLastWave()
    {
        _levelCompletePanel.SetActive(true);
    }

    private void UpdateWaveNumber()
    {
        _allWavesText.text = $"{_currentWave}";
        _currentWaveText.gameObject.SetActive(false);
        _currentWaveText.gameObject.SetActive(true);
    }

    public void ShowWaveNumber(int waveNumber)
    {
        _currentWave = waveNumber;
        CurrentWaveString = _currentWave.ToString();
        UpdateWaveNumber();
    }
}