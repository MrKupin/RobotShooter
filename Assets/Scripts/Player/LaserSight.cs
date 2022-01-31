using UnityEngine;

public class LaserSight : MonoBehaviour
{
    [SerializeField] private AimingStates _aimingStates;
    [SerializeField] private Transform _gunpoint;
    [SerializeField] private LineRenderer _lineRenderer;
    private Ray _ray = new Ray();
    private RaycastHit _hit = new RaycastHit();

    void Update()
    {
        if (_aimingStates.IsAiming)
        {
            _lineRenderer.enabled = true;
            Aim();
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }

    public void Aim()
    {
        _ray.origin = _gunpoint.position;
        _ray.direction = _gunpoint.forward;

        if (Physics.Raycast(_ray, out _hit))
        {
            _lineRenderer.useWorldSpace = true;
            _lineRenderer.SetPosition(0, _gunpoint.position);
            _lineRenderer.SetPosition(1, _hit.point);
        }
        else
        {
            _lineRenderer.useWorldSpace = false;
            _lineRenderer.SetPosition(0, new Vector3(0, 0, 2000));
            _lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}
