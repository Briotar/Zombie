using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuView : MonoBehaviour
{
    private LevelButton[] _levelButtons;
    private int _defaultValue = -1;
    private int _currentLevel;

    private void Start()
    {
        _levelButtons = GetComponentsInChildren<LevelButton>();
        _currentLevel = PlayerPrefs.GetInt("_currentLevel", _defaultValue);

        if (_currentLevel == _defaultValue)
        {
            _levelButtons[0].SetActive();
        }
        else
        {
            int levelCount = 1;

            for (int i = 0; i < _levelButtons.Length; i++)
            {
                if (levelCount <= _currentLevel)
                {
                    _levelButtons[i].SetActive();
                    levelCount++;
                }
            }
        }
    }

    public void OnButtonClick(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}