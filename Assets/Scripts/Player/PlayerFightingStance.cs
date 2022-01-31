using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFightingStance : MonoBehaviour
{
    [SerializeField] private AimingStates _aimingStates;
    [SerializeField] private EventTrigger _shotEvent;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _aimingStates.OnEnabledAiming += Aim;
        _aimingStates.OnDisabledAiming += Aim;
    }

    private void Aim()
    {
        if (_aimingStates.IsAiming)
        {
            _shotEvent.gameObject.SetActive(true);
            _animator.SetBool("Aiming", true);
        }
        else
        {
            _shotEvent.gameObject.SetActive(false);
            _animator.SetBool("Aiming", false);
        }
    }

    private void OnDisable()
    {
        _aimingStates.OnEnabledAiming -= Aim;
        _aimingStates.OnDisabledAiming -= Aim;
    }
}
