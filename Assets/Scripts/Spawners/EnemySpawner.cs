using UnityEngine;

namespace Spawners
{
    public class EnemySpawner : Spawner<Enemy.Enemy>, IEnemySpawner
    {
        public void Spawn(Vector3 position)
        {
            Enemy.Enemy enemy = InstantiateObject();
            enemy.transform.position = position;
        }
    }
}