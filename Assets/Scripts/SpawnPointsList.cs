using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsList : MonoBehaviour
{
    private SpawnPoint[] _allSpawnPoints;

    private void Start()
    {
        _allSpawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    public Vector3 GetSpawnPoint()
    {
        List<SpawnPoint> currentList = new List<SpawnPoint>();

        for (int i = 0; i < _allSpawnPoints.Length; i++)
        {
            if(_allSpawnPoints[i].isActiveAndEnabled)
            {
                _allSpawnPoints[i].gameObject.SetActive(false);
                return _allSpawnPoints[i].transform.position;
            }
        }

        return _allSpawnPoints[0].transform.position;
        /*List<SpawnPoint> currentList = new List<SpawnPoint>();

        for (int i = 0; i < _allSpawnPoints.Length; i++)
        {
            Vector3 vpPos = Camera.main.WorldToViewportPoint(_allSpawnPoints[i].transform.position);
            if (vpPos.x <= 0f || vpPos.x >= 1f || vpPos.y <= 0f || vpPos.y >= 1f)
            {
                currentList.Add(_allSpawnPoints[i]);
            }
        }

        System.Random rand = new System.Random();
        var index = rand.Next(0, currentList.Count);

        return currentList[index].transform.position;*/
    }
}