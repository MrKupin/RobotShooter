using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private Material[] _defaultMaterials;
    [SerializeField] private TurretAiming _turretAiming;
    [SerializeField] private TurretShooting _turretShooting;
    [SerializeField] private Collider _collider;

    private void Awake()
    {
        CreateDefaultMaterials();
    }

    public void InitTurret(ActiveEnemies activeEnemies)
    {
        _turretAiming.Init(activeEnemies);
        _turretShooting.enabled = true;
        _collider.enabled = true;
    }

    private void CreateDefaultMaterials()
    {
        _defaultMaterials = new Material[_meshRenderers.Length];
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            _defaultMaterials[i] = Instantiate(_meshRenderers[i].material);
        }
    }

    public void SetMaterial(Material material)
    {
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material = material;
        }
    }

    public void SetDefaultMaterial()
    {
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            _meshRenderers[i].material = _defaultMaterials[i];
        }
    }
}
