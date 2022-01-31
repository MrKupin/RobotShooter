using System;
using System.Collections.Generic;
using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    public Action OnAimed;
    [SerializeField] private Transform _tower;
    [SerializeField] private Transform _tower1;
    [SerializeField] private ActiveEnemies _activeEnemies;
    private List<Enemy> _sortedEnemies = new List<Enemy>();

    public void Init(ActiveEnemies activeEnemies)
    {
        _activeEnemies = activeEnemies;
    }

    private void FixedUpdate()
    {
        if (_activeEnemies)
        {
            SortEnemies();
            Aim();
        }
    }

    private void SortEnemies()
    {
        _sortedEnemies = _activeEnemies.GetEnemy();
        foreach (Enemy enemy in _sortedEnemies)
        {
            enemy.CalculateDistanceToTurret(transform.position);
        }
        _sortedEnemies.Sort((x, y) => x.DistanceToTurret.CompareTo(y.DistanceToTurret));
    }

    private void Aim()
    {
        Vector3 target = _sortedEnemies[0].gameObject.transform.position - _tower.position;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(target.x, 0, target.z));
        _tower.rotation = Quaternion.RotateTowards(_tower.rotation, targetRotation, 0.6f);
        Quaternion targetRotation1 = Quaternion.LookRotation(new Vector3(target.x, target.y, target.z));
        _tower1.rotation = Quaternion.RotateTowards(_tower1.rotation, targetRotation1, 0.6f);
        _tower1.rotation = Quaternion.Euler(_tower1.rotation.eulerAngles.x, _tower.rotation.eulerAngles.y, 0);
    }
}
