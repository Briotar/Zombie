using UnityEngine;

[RequireComponent(typeof(EnemyMover))] 
[RequireComponent(typeof(Animator))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage = 2f;
    
    private House _house;
    private EnemyMover _mover;
    private Animator _animator;

    private void OnEnable()
    {
        _mover = GetComponent<EnemyMover>();

        _mover.EnemyReachedTarget += (Transform house) =>
        {
            StartAttack(house);
        };
    }

    private void OnDisable()
    {
        _mover.EnemyReachedTarget -= (Transform house) =>
        {
            StartAttack(house);
        };
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void StartAttack(Transform house)
    {
        _house = house.gameObject.GetComponent<House>();
        _animator.SetBool(AnimatorEnemyController.Params.IsAttacking, true);
    }

    public void Attack()
    {
        _house.Applydamage(_damage);
    }
}