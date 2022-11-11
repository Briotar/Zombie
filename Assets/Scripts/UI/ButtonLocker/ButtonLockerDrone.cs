using UnityEngine;

public class ButtonLockerDrone : ButtonLocker
{
    protected override void LoadButton()
    {
        string drone = PlayerPrefs.GetString("_currentDrone", "none");

        if (drone == "drone")
            OnButtonClick();
    }
}