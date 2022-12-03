using UnityEngine;
public class DefensiveBuilding : Building
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AttackPointsList _list;
    [SerializeField] private BuildingSaver _saver;

    private AttackPoint[] _attackPoints;
    private bool _isBuilded = false;

    public bool IsBuilded => _isBuilded;

    protected override void Start()
    {
        base.Start();

        _attackPoints = GetComponentsInChildren<AttackPoint>();
    }

    protected override void Destroy()
    {
        _animator.Play(AnimatorBuildingController.States.HideBuilding);
        _isBuilded = false;
        _list.RemovePointsFromList(_attackPoints);

        _saver.DeleteBuilding();
    }

    public void Build()
    {
        _animator.enabled = true;
        _isBuilded = true;

        _list.AddPointsToList(_attackPoints);
        _saver.SaveBuilding();
    }
}