using System;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;

public class RewardedVideo : MonoBehaviour
{
    [SerializeField] private PlayerCollector _collector;
    [SerializeField] private int _coinsCount;

    private event Action _onVideoOpened;
    private event Action _onRewardedCallback;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private void OnEnable()
    {
        _onRewardedCallback += () =>
        {
            SetRevardForVideo();
        };
    }

    private void OnDisable()
    {
        _onRewardedCallback -= () =>
        {
            SetRevardForVideo();
        };
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    private void SetRevardForVideo()
    {
        _collector.IncreaseWhiteCoins(_coinsCount);
        gameObject.SetActive(false);
    }

    public void OnShowVideo()
    {
        VideoAd.Show(_onVideoOpened, _onRewardedCallback);
    }
}