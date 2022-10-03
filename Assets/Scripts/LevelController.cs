using System.Collections;
using UnityEngine;

[RequireComponent(typeof(WaveController))]
public class LevelController : MonoBehaviour
{
    [SerializeField] private int _maxWavesCount = 3;
    [SerializeField] private int _endGameTime = 3;
    [SerializeField] private GameObject _levelCompletePanel;

    private WaveController _waveController;

    private void OnEnable()
    {
        _waveController = GetComponent<WaveController>();

        _waveController.NextWave += (int wave) =>
        {
            CheckIsThatWaveLast(wave);
        };
    }

    private void OnDisable()
    {
        _waveController.NextWave -= (int wave) =>
        {
            CheckIsThatWaveLast(wave);
        };
    }

    private void CheckIsThatWaveLast(int wave)
    {
        if (wave == _maxWavesCount)
        {
            Debug.Log("Last wave!");
        }
        else if (wave > _maxWavesCount)
        {
            _levelCompletePanel.SetActive(true);
            StartCoroutine(EndLevel());
        }    
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(_endGameTime);

        Time.timeScale = 0f;
    }
}