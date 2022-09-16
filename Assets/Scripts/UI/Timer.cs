using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    private TMP_Text _text;
    private float _currentTime = 7f;
    private int _currentTimeInt;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        _currentTimeInt = (int)_currentTime;

        _text.text = _currentTimeInt.ToString();
    }
}
