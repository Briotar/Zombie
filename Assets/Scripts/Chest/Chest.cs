using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour
{
    [SerializeField] private Transform _chestCenter;
    [SerializeField] private int _rewardsCount;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _timeDelay = 0.1f;
    [SerializeField] private GameObject _coinEffect;

    private Animator _animator;

    public event Action Opened;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        Opened.Invoke();

        _coinEffect.SetActive(false);
        _animator.SetBool(AnimatorChestController.Params.IsChestOpened, true);

        StartCoroutine(EffectDelay());
        RewardsManager.Instance.SpawnReward(_chestCenter, _rewardsCount);
    }

    private IEnumerator EffectDelay()
    {
        yield return new WaitForSeconds(_timeDelay);

        _effect.Play();
    }
}