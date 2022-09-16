using UnityEngine;

public class NextWaveView : MonoBehaviour
{
    [SerializeField] private GameObject _nextWavePanel;
    
    public void OnNextWaveStarting()
    {
        _nextWavePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
