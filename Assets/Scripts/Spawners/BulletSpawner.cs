using Enemy;
using UnityEngine;

namespace Spawners
{
    public class BulletSpawner : Spawner<Bullet>, IBulletSpawner
    {
        public void Spawn(Vector3 position)
        {
            if (IsOverflow)
                return;
            
            Bullet bullet = InstantiateObject();
            bullet.transform.position = position;
        }
    }
}