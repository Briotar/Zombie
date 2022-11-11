using UnityEngine;

public class ButtonLockerShootingSpeed : ButtonLocker
{
    [SerializeField] private float _minShootingSpeed = 0.3f;

    protected override void LoadButton()
    {
        float shootingSpeed = PlayerPrefs.GetFloat("_shootingSpeedIncrease", Mathf.Infinity);

        if (shootingSpeed <= _minShootingSpeed)
            OnButtonClick();
    }
}