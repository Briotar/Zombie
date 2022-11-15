using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    private Image _image;
    private TMP_Text _text;
    private Button _button;
    private int _maxAlpha = 255;

    private void OnEnable()
    {
        _image = GetComponentInChildren<Image>();
        _text = GetComponentInChildren<TMP_Text>();
        _button = GetComponentInChildren<Button>();
    }

    public void SetActive()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _maxAlpha);
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _maxAlpha);
        _button.enabled = true;
    }
}