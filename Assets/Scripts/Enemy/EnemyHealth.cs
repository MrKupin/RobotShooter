using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private ActiveEnemies _activeEnemies;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private PlayerSearch _playerSearch;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;

    public override void CheckHealth()
    {
        base.CheckHealth();
        if (_health > 0)
            return;

        _activeEnemies.DisableEnemy(_enemy);
        _playerSearch.enabled = false;
        _rigidbody.useGravity = false;
        _collider.enabled = false;
    }
}
