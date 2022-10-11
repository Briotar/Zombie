using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(WaveController))]
public class LevelController : MonoBehaviour
{
    [SerializeField] private int _endGameTime = 3;
    [SerializeField] private GameObject _levelCompletePanel;
    [SerializeField] private int _nextSceneNumber = 1;

    private WaveController _waveController;

    private void OnEnable()
    {
        _waveController = GetComponent<WaveController>();

        _waveController.LastWave += () =>
        {
            EndGame();
        };
    }

    private void OnDisable()
    {
        _waveController.LastWave -= () =>
        {
            EndGame();
        };
    }

    private void EndGame()
    {
        StartCoroutine(EndLevel());
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(_endGameTime);

        SceneManager.LoadScene(1);
    }
}