using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    private void Start()
    {
        StartCoroutine(Score());
    }

    private IEnumerator Score()
    {
        yield return Agava.YandexGames.YandexGamesSdk.Initialize();

        StartCoroutine(SetScore());
    }

    private IEnumerator SetScore()
    {
        yield return new WaitForSeconds(5f);

        var ld = "Leaderboard";
        Agava.YandexGames.Leaderboard.SetScore(ld, 10);
    }
#endif
}