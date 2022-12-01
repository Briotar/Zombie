using System;
using System.Collections;
using UnityEngine;
using Agava.YandexGames;

public class ChestVideoAd : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private Chest[] _chests;
    private Chest _openedChest;
    private bool _isFirstShow = true;

    private event Action _onVideoOpened;
    private event Action _onRewardedCallback;


    private void OnEnable()
    {
        _chests = GetComponentsInChildren<Chest>();

        for (int i = 0; i < _chests.Length; i++)
        {
            _chests[i].Opened += (chest) =>
            {
                ShowPanelVideoButton(chest);
            };
        }

        _onRewardedCallback += () =>
        {
            IncreaseCoins();
        };
    }

    private void OnDisable()
    {
        for (int i = 0; i < _chests.Length; i++)
        {
            _chests[i].Opened -= (chest) =>
            {
                ShowPanelVideoButton(chest);
            };
        }

        _onRewardedCallback -= () =>
        {
            IncreaseCoins();
        };
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    private void ShowPanelVideoButton(Chest chest)
    {
        if(_isFirstShow)
        {
            _openedChest = chest;
            _panel.SetActive(true);
            Time.timeScale = 0;

            _isFirstShow = false;
        }
    }

    private void IncreaseCoins()
    {
        _panel.SetActive(false);
        _openedChest.SpawnCoins();
        Time.timeScale = 1;
    }

    public void OnClosePanel()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnShowVideo()
    {
        VideoAd.Show(_onVideoOpened, _onRewardedCallback);
    }
}