using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using Agava.YandexGames;

[DisplayName("My Startup Selector")]
[Serializable]
public class MySelector : IStartupLocaleSelector
{
    private string _language;
    private float _waitTime = 0.1f;

    private IEnumerator Init()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        while (!YandexGamesSdk.IsInitialized)
        {
            yield return new WaitForSeconds(_waitTime);

            if (YandexGamesSdk.IsInitialized)
            {
                _language = YandexGamesSdk.Environment.i18n.lang;
                LocalizationSettings.ProjectLocale = LocalizationSettings.AvailableLocales.GetLocale(_language);
            }
        }
    }

    public Locale GetStartupLocale(ILocalesProvider availableLocales)
    {
        Init();

        if (YandexGamesSdk.IsInitialized)
        {
            _language = YandexGamesSdk.Environment.i18n.lang;
            LocalizationSettings.ProjectLocale = LocalizationSettings.AvailableLocales.GetLocale(_language);
        }

        return availableLocales.GetLocale(_language);
    }
}