using UnityEngine;

public class EnemyShooting : NPCShooting
{
    [SerializeField] private PlayerSearch _playerSearch;

    private void Update()
    {
        if (_playerSearch.SearchStatus != SearchStatus.LookingFor)
            Ray();
    }

    public override void Ray()
    {
        base.Ray();
        if (Physics.Raycast(_ray, out _hit))
            if (_hit.collider.GetComponent<Player>())
                Shoot();
    }
}
