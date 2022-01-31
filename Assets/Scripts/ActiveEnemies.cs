using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemies : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    public List<Enemy> GetEnemy()
    {
        List<Enemy> enemies = new List<Enemy>();
        foreach (Enemy enemy in _enemies)
        {
            enemies.Add(enemy);
        }
        return enemies;
    }

    public void DisableEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }
}
