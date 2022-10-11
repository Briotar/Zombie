using UnityEngine;

public class Wall : Building
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AttackPointsList _list;

    private AttackPoint[] _attackPoints;

    protected override void Start()
    {
        base.Start();

        _attackPoints = GetComponentsInChildren<AttackPoint>();
    }

    public void Build()
    {
        _animator.enabled = true;
        _list.AddPointsToList(_attackPoints);
    }
}