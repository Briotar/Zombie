using UnityEngine;
using System.Collections;

public class BuildingSaver : MonoBehaviour
{
    [SerializeField] private DefensiveBuilding _building;
    [SerializeField] private string _buildingName;
    [SerializeField] private UpgradePanel _panel;

    private void Start()
    {
        //PlayerPrefs.DeleteKey(_buildingName);
        int count = PlayerPrefs.GetInt(_buildingName, -1);

        if (count != -1)
            StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);

        _building.Build();
        _panel.gameObject.SetActive(false);
    }

    public void SaveBuilding()
    {
        PlayerPrefs.SetInt(_buildingName, 1);
        PlayerPrefs.Save();
    }

    public void DeleteBuilding()
    {
        PlayerPrefs.DeleteKey(_buildingName);
        PlayerPrefs.Save();
    }
}