using UnityEngine;

public class DefensiveBuilding : Building
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AttackPointsList _list;

    private AttackPoint[] _attackPoints;
    private bool _isBuilded = false;

    public bool IsBuilded => _isBuilded;

    protected override void Start()
    {
        base.Start();

        _attackPoints = GetComponentsInChildren<AttackPoint>();
    }

    public void Build()
    {
        _animator.enabled = true;
        _isBuilded = true;

        _list.AddPointsToList(_attackPoints);
    }
}