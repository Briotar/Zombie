using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour
{
    [SerializeField] private Transform _chestCenter;
    [SerializeField] private int _rewardsCount;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetBool(AnimatorChestController.Params.IsChestOpened, true);
        RewardsManager.Instance.SpawnReward(_chestCenter, 5);
    }
}