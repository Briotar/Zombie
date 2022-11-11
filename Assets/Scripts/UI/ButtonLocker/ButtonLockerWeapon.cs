using UnityEngine;

public class ButtonLockerWeapon : ButtonLocker
{
    protected override void LoadButton()
    {
        string drone = PlayerPrefs.GetString("_currentWeapon", "none");

        if (drone == "rifle")
            OnButtonClick();
    }
}