using UnityEngine;

namespace Spawners
{
    public class EnemySpawner : Spawner<Enemy.Enemy>, IEnemySpawner
    {
        [SerializeField] private BulletSpawner _bulletSpawner;

        public void Spawn(Vector3 position)
        {
            Enemy.Enemy enemy = InstantiateObject();
            enemy.Initialize(position, _bulletSpawner);
        }
    }
}