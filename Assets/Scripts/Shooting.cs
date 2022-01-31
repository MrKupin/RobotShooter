using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    private bool _isShoot;

    public void Shoot()
    {
        if (_isShoot == false)
        {
            _animator.SetTrigger("Shoot");
            _isShoot = true;
        }
    }

    public void StopShooting()
    {
        _isShoot = false;
    }
}
