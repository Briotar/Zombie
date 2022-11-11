using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonLocker : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        LoadButton();
    }

    protected virtual void LoadButton()
    {
    }

    public void OnButtonClick()
    {
        _title.gameObject.SetActive(true);
        _button.enabled = false;
    }
}