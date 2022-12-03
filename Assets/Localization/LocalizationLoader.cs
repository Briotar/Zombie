using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationLoader : MonoBehaviour
{
    private void Start()
    {
        string language = PlayerPrefs.GetString("lang", "none");

        if (language == "none")
            language = "ru";

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(language);
    }
}
