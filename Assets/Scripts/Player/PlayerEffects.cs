using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _upgradeEffect;

    public void PlayUpgradeEffect()
    {
        _upgradeEffect.Play();
    }
}
