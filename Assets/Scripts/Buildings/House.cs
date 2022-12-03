using System;
using UnityEngine;

public class House : Building
{
    [SerializeField] private ParticleSystem _destroyEffect;
    [SerializeField] private MeshRenderer _house;
    [SerializeField] private MeshRenderer _solarPanel;
    [SerializeField] private Material _destroedHouse;
    [SerializeField] private Material _destroedSolarPanel;

    public event Action GameOver;

    protected override void Destroy()
    {
        GameOver.Invoke();
        _destroyEffect.Play();

        _house.material = _destroedHouse;
        _solarPanel.material = _destroedSolarPanel;
    }
}