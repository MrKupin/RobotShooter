using UnityEngine;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Ray _ray;
    private RaycastHit _hit;
    private SearchStatus _searchStatus;
    public SearchStatus SearchStatus => _searchStatus;

    void Update()
    {
        Vector3 direction = _player.position - transform.position;
        _ray.origin = transform.position;
        _ray.direction = direction;
        float angle = Vector3.Angle(direction, transform.forward);

        if (Physics.Raycast(_ray, out _hit))
        {
            Player player = _hit.collider.GetComponent<Player>();

            if (_searchStatus == SearchStatus.LookingFor && player == true && direction.magnitude < 10 && angle < 120)
                _searchStatus = SearchStatus.Found;

            else if (direction.magnitude < 4 && _searchStatus == SearchStatus.Found && player == true)
                _searchStatus = SearchStatus.Attack;

            else if (_searchStatus == SearchStatus.Attack && player == false)
                _searchStatus = SearchStatus.Found;

            else if (_searchStatus == SearchStatus.Attack && direction.magnitude > 4)
                _searchStatus = SearchStatus.Found;

            else if (direction.magnitude > 10)
                _searchStatus = SearchStatus.LookingFor;
        }
    }

    private void OnDisable()
    {
        _searchStatus = SearchStatus.LookingFor;
    }
}

public enum SearchStatus
{
    LookingFor,
    Found,
    Attack
}
