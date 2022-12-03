using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using Agava.YandexGames;

public class LocalizationSettingsSetter : MonoBehaviour
{
    private string _language;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        _language = YandexGamesSdk.Environment.i18n.lang;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(_language);

        PlayerPrefs.SetString("lang", _language);
    }
}