using UnityEngine;

public class Drone : MonoBehaviour
{   
    private void OnEnable()
    {
        ProgressSaver.Instance.SaveDrone();
    }
}
