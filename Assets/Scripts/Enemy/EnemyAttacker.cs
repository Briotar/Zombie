using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage = 2f;
    [SerializeField] private Animator _animator;

    private Building _building;
    private EnemyMover _mover;

    private void OnEnable()
    {
        _mover = GetComponent<EnemyMover>();

        _mover.EnemyReachedTarget += (Transform building) =>
        {
            StartAttack(building);
        };
    }

    private void OnDisable()
    {
        _mover.EnemyReachedTarget -= (Transform building) =>
        {
            StartAttack(building);
        };
    }

    private void Start()
    {
        //_animator = GetComponent<Animator>();
    }

    private void StartAttack(Transform building)
    {
        _building = building.gameObject.GetComponent<Building>();
        _animator.SetBool(AnimatorEnemyController.Params.IsAttacking, true);
    }

    public void Attack()
    {
        _building.Applydamage(_damage);
    }
}