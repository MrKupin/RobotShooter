using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private Shooting _shooting;
    [SerializeField] private TurretSpawner _turretSpawner;

    public override void CheckHealth()
    {
        base.CheckHealth();
        if (_health > 0)
            return;

        _joystick.enabled = false;
        _playerRotation.enabled = false;
        _shooting.enabled = false;
        _turretSpawner.enabled = false;
    }
}
