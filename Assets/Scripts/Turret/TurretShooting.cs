using UnityEngine;

public class TurretShooting : NPCShooting
{
    public override void Ray()
    {
        base.Ray();
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.GetComponent<Enemy>())
                Shoot();
        }
    }
}
