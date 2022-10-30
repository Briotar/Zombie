using UnityEngine;
using System.Collections;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private House _house;
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timeDelay = 2f;

    private void OnEnable()
    {
        _house.GameOver += () =>
        {
            ShowGameOverScreen();
        };
    }

    private void OnDisable()
    {
        _house.GameOver -= () =>
        {
            ShowGameOverScreen();
        };
    }

    private void ShowGameOverScreen()
    {
        StartCoroutine(EndGameDelay());
        _panel.SetActive(true);
    }

    private IEnumerator EndGameDelay()
    {
        yield return new WaitForSeconds(_timeDelay);

        Time.timeScale = 0;
    }
}