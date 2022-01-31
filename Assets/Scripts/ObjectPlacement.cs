using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    private Transform _gameObject;
    [SerializeField] private Transform _rayPoint;
    private Ray _ray = new Ray();
    private RaycastHit _hit = new RaycastHit();

    private void Update()
    {
        if (_gameObject)
            PlaceObject();
    }

    public void SetObject(Transform gameObject)
    {
        _gameObject = gameObject;
    }

    public void PlaceObject()
    {
        _ray.origin = _rayPoint.position;
        _ray.direction = _rayPoint.forward;

        if (Physics.Raycast(_ray, out _hit))
        {
            _gameObject.transform.up = _hit.normal;
            _gameObject.transform.position = _hit.point;
        }
    }

    public bool CheckRotation()
    {
        Quaternion rotation = _gameObject.transform.rotation;
        if (Mathf.Abs(rotation.x) >= 0.1 || Mathf.Abs(rotation.z) >= 0.1)
{
            return false;
        }
        else
        {
            return true;
        }
    }
}
