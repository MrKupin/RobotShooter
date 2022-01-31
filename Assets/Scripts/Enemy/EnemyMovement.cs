using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerSearch _playerSearch;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _player;

    void FixedUpdate()
    {
        Move();
        Animation();
    }

    private void Move()
    {
        if (_playerSearch.SearchStatus == SearchStatus.Found)
            _navMeshAgent.SetDestination(_player.position);
        else
            _navMeshAgent.ResetPath();
    }

    private void Animation()
    {
        if (_playerSearch.SearchStatus == SearchStatus.Found)
            _animator.SetBool("Run", true);
        else
            _animator.SetBool("Run", false);
    }
}
