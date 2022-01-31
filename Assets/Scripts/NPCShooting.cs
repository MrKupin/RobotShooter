using UnityEngine;

public class NPCShooting : Shooting
{
    [SerializeField] private Transform _gunPoint;
    protected Ray _ray = new Ray();
    protected RaycastHit _hit = new RaycastHit();

    void Update()
    {
        Ray();
    }

    public virtual void Ray()
    {
        _ray.origin = _gunPoint.position;
        _ray.direction = _gunPoint.forward;
    }
}
