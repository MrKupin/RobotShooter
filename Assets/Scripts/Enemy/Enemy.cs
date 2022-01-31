using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _distanceToTurret;
    public float DistanceToTurret => _distanceToTurret;

    public float CalculateDistanceToTurret(Vector3 _turretPosition) => _distanceToTurret = (_turretPosition - transform.position).magnitude;
}
