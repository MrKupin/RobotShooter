using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPlacement _objectPlacement;
    private Turret _turret;
    [SerializeField] private Turret _turretPrefab;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _redMaterial;
    [SerializeField] private Button _createButton;
    [SerializeField] private Button _placementButton;
    [SerializeField] private Button _stopCreatingButton;
    [SerializeField] private NavMeshSurface _navMeshSurface;
    [SerializeField] private ActiveEnemies _activeEnemies;
    private bool _rotationIsSet;

    void Update()
    {
        if (_turret == null)
            return;

        _rotationIsSet = _objectPlacement.CheckRotation();
        SetMaterial();
    }

    private void SetMaterial()
    {
        if (_rotationIsSet)
            _turret.SetMaterial(_greenMaterial);
        else
            _turret.SetMaterial(_redMaterial);
    }

    public void InstantiateTuret()
    {
        if (enabled == false)
            return;

        _turret = Instantiate(_turretPrefab);
        _objectPlacement.SetObject(_turret.transform);
        _createButton.gameObject.SetActive(false);
        _placementButton.gameObject.SetActive(true);
        _stopCreatingButton.gameObject.SetActive(true);
    }

    public void FinishCreation()
    {
        if (_rotationIsSet == false)
            return;

        _turret.SetDefaultMaterial();
        _turret.InitTurret(_activeEnemies);
        _turret = null;
        _objectPlacement.SetObject(null);
        _navMeshSurface.BuildNavMesh();
        _createButton.gameObject.SetActive(true);
        _placementButton.gameObject.SetActive(false);
        _stopCreatingButton.gameObject.SetActive(false);
    }

    public void StopCreating()
    {
        Destroy(_turret.gameObject);
        _turret = null;
        _objectPlacement.SetObject(null);
        _createButton.gameObject.SetActive(true);
        _placementButton.gameObject.SetActive(false);
        _stopCreatingButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (_turret != null)
            StopCreating();
    }
}
