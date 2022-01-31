using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    private List<Bullet> _bullets = new List<Bullet>();
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private int _bulletCount = 10;

    private void Start()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            _bullets.Add(Instantiate(_bulletPrefab));
        }
    }

    public void GetBullet()
    {
        foreach (Bullet bullet in _bullets)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.transform.position = _gunPoint.position;
                bullet.transform.rotation = _gunPoint.rotation;
                bullet.gameObject.SetActive(true);
                return;
            }
        }
    }
}
