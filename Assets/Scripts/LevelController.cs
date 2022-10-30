using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(WaveController))]
[RequireComponent(typeof(ProgressSaver))]
public class LevelController : MonoBehaviour
{
    [SerializeField] private int _endGameTime = 3;
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
        ProgressSaver.Instance.SaveLevel(_nextSceneNumber);
        ProgressSaver.Instance.SaveWave(1);

        yield return new WaitForSeconds(_endGameTime);

        Time.timeScale = 0f;
    }

    public void OnMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnNextLevelButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_nextSceneNumber);
    }

    public void OnRetryButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene((_nextSceneNumber - 1));
    }
}