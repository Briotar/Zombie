using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
public class PressurePanel : MonoBehaviour
{
    [SerializeField] private Chest _chest;

    private Collider _collider;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            _chest.Open();
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 255);
            _collider.enabled = false;
        }
    }
}