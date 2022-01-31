using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _movementSpeed;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private float _runningSpeed;
    [SerializeField] private AimingStates _aiming;
    [SerializeField] Animator _animator;
    public Vector3 GetMoveDirection => _moveDirection;

    public void Move(Vector2 moveDirection)
    {
        _moveDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
        transform.localPosition += _moveDirection * _movementSpeed;
        transform.parent.position = transform.position;
        transform.position = transform.parent.position;
        if (_moveDirection != Vector3.zero && _aiming.IsAiming == false)
        {
            transform.localRotation = Quaternion.LookRotation(_moveDirection);
        }
        PlayAnimations();
    }

    private void PlayAnimations()
    {
        float directionX = 0;
        float directionZ = 0;
        bool isRunning = false;

        if (_aiming.IsAiming)
        {
            if (Mathf.Abs(_moveDirection.x) > Mathf.Abs(_moveDirection.z))
                directionX = _moveDirection.x;
            else
                directionZ = _moveDirection.z;
            _movementSpeed = _walkingSpeed;
        }
        else
        {
            if (_moveDirection != Vector3.zero)
                isRunning = true;
            else
                isRunning = false;
            _movementSpeed = _runningSpeed;
        }
        _animator.SetFloat("Walking", directionZ);
        _animator.SetFloat("WalkingLeftRight", directionX);
        _animator.SetBool("Running", isRunning);
    }
}
