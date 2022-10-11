using UnityEngine;
using TMPro;

public class NextWaveView : MonoBehaviour
{
    [SerializeField] private GameObject _nextWavePanel;
    [SerializeField] private TimerToNextWave _timer;

    public void OnNextWaveStarting()
    {
        _nextWavePanel.SetActive(true);
        gameObject.SetActive(false);
        _timer.enabled = true;
    }
}