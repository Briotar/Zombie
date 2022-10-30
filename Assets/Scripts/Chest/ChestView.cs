using UnityEngine;
using TMPro;

public class ChestView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Chest[] _chests;
    private int _currentCount;
    private int _maxCount;

    private void Start()
    {
        _chests = GetComponentsInChildren<Chest>();
        _maxCount = _chests.Length;
        _currentCount = 0;
        ShowChestCount();

        for (int i = 0; i < _chests.Length; i++)
        {
            _chests[i].Opened += () =>
            {
                IncreaseChestCount();
            };
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _chests.Length; i++)
        {
            _chests[i].Opened -= () =>
            {
                IncreaseChestCount();
            };
        }
    }

    private void IncreaseChestCount()
    {
        _currentCount++;
        ShowChestCount();
    }


    private void ShowChestCount()
    {
        _text.text = $"{_currentCount}/{_maxCount}";
    }
}