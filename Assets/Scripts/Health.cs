using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private HealthBar _healthBar;
    protected float _health = 1;

    public virtual void CheckHealth()
    {
        if (_health <= 0)
            _animator.SetTrigger("Die");
    }

    private void TakeDamage(Bullet bullet)
    {
        _health -= bullet.Damage;
        _healthBar.SetHealth(_health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(bullet);
            CheckHealth();
        }
    }
}
