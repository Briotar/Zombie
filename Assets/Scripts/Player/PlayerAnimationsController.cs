using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private QuarterChooser _quarterChooser;

    private float _minVelocity = 0.001f;

    private int _enemyQuarter;
    private int _directionQuarter;

    private void FixedUpdate()
    {
        if(_shooter.TargetPosition != null)
            DetermineQuarter();

        if (_rigidbody.velocity.magnitude >= _minVelocity)
        {
            if(_shooter.IsShoot)
                if(_enemyQuarter == _directionQuarter)
                {
                    SetAnimatorState(true, false, false, false);
                }
                else if(Mathf.Abs(_enemyQuarter - _directionQuarter) == 2)
                {
                    SetAnimatorState(false, true, false, false);
                }
                else if(Mathf.Abs(_enemyQuarter - _directionQuarter) == 1)
                {
                    SetAnimatorState(false, false, true, false);
                }
                else
                {
                    SetAnimatorState(false, true, false, false);
                }
            else
                SetAnimatorState(true, false, false, true);
        }
        else
        {
            SetAnimatorState(false, false, false, false);
        }
    }

    private void DetermineQuarter()
    {
        Vector3 rotation = (_shooter.TargetPosition - transform.position).normalized;
        Vector2 rotationXY = new Vector2(rotation.x, rotation.z);

        _enemyQuarter = _quarterChooser.ChooseQuarter(rotationXY);
        _directionQuarter = _quarterChooser.ChooseQuarter(_joystick.Direction);
    }

    private void SetAnimatorState(bool isWalking, bool isWalkBack, bool isStrafe, bool isRunning)
    {
        _animator.SetBool(AnimatorPlayerController.Params.IsWalking, isWalking);
        _animator.SetBool(AnimatorPlayerController.Params.IsWalkBack, isWalkBack);
        _animator.SetBool(AnimatorPlayerController.Params.IsStrafe, isStrafe);
        _animator.SetBool(AnimatorPlayerController.Params.IsRunning, isRunning);
    }

    public void PlayShootAnimation()
    {
        _animator.SetBool(AnimatorPlayerController.Params.IsShooting, true);
    }

    public void StopShootAnimation()
    {
        _animator.SetBool(AnimatorPlayerController.Params.IsShooting, false);
    }

    public void SetShotgun()
    {
        _animator.SetBool(AnimatorPlayerController.Params.IsShotgun, true);
    }

    public void SetRifle()
    {
        _animator.SetBool(AnimatorPlayerController.Params.IsRifle, true);
    }
}