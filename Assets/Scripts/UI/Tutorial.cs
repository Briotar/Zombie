using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Start()
    {
        string tutorial = PlayerPrefs.GetString("tutorial", "none");

        if (tutorial != "none")
            gameObject.SetActive(false);
    }

    public void OnTutorialShowed()
    {
        Time.timeScale = 0;
    }

    public void OnButtonClose()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetString("tutorial", "yes");
        Time.timeScale = 1;
    }
}