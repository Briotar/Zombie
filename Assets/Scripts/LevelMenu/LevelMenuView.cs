using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuView : MonoBehaviour
{
    public void OnButtonClick(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}