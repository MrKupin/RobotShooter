using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private PlayerSearch _playerSearch;
    [SerializeField] private Transform _player;

    private void FixedUpdate()
    {
        if (_playerSearch.SearchStatus != SearchStatus.LookingFor)
            Rotation();
    }

    private void Rotation()
    {
        Vector3 direction = _player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
    }
}
