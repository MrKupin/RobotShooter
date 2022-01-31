using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimingStates : MonoBehaviour
{
    public Action OnEnabledAiming;
    public Action OnDisabledAiming;
    [SerializeField] private EventTrigger _aimEnableEvent;
    [SerializeField] private EventTrigger _aimDisableEvent;
    private bool _isAiming;
    public bool IsAiming => _isAiming;

    public void EnableAiming()
    {
        _isAiming = true;
        OnEnabledAiming?.Invoke();
        _aimDisableEvent.gameObject.SetActive(true);
        _aimEnableEvent.gameObject.SetActive(false);
    }

    public void DisableAiming()
    {
        _isAiming = false;
        OnDisabledAiming?.Invoke();
        _aimEnableEvent.gameObject.SetActive(true);
        _aimDisableEvent.gameObject.SetActive(false);
    }
}
