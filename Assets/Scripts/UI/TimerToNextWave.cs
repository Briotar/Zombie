using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class TimerToNextWave : MonoBehaviour
{
    [SerializeField] private WaveController _waveController;
    [SerializeField] private TMP_Text _text;

    private Animator _animator;
    private float _currentTime;
    private int _currentTimeInt;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _currentTime = 7f;
        _currentTimeInt = (int)_currentTime;
    }

    private void Update()
    {
        if (_currentTimeInt == 0)
        {
            _waveController.StartNextWave();
            _animator.SetBool(AnimatorNextWaveController.Params.IsNeedHidePanel, true);
        }
        else
        {
            _currentTime -= Time.deltaTime;
            _currentTimeInt = (int)_currentTime;

            _text.text = _currentTimeInt.ToString();
        }
    }

    public void OnButton()
    {
        _currentTimeInt = 0;
    }

    public void OnNextWaveStarted()
    {
        gameObject.SetActive(false);
    }
}