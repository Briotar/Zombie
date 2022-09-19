using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class DroneBateryController : MonoBehaviour
{
    private Canvas _canvas;
    private Quaternion _startRotation;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = _startRotation;
    }
}