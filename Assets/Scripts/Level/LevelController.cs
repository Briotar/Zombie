using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

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

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    private void EndGame()
    {
        StartCoroutine(EndLevel());
    }

    private IEnumerator EndLevel()
    {
        OnShowSimpleAd();
        ProgressSaver.Instance.SaveLevel(_nextSceneNumber);
        ProgressSaver.Instance.SaveWave(1);

        yield return new WaitForSeconds(_endGameTime);

        Time.timeScale = 0f;
    }

    private void OnShowSimpleAd()
    {
        InterstitialAd.Show();
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