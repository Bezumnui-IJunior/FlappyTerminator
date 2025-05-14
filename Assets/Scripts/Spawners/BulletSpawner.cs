using Props;
using UnityEngine;

namespace Spawners
{
    public class BulletSpawner : Spawner<Bullet>, IBulletSpawner
    {
        public void Spawn(Vector3 position, Vector3 direction, Transform owner, float speed, bool enforce)
        {
            if (IsOverflow && enforce == false)
                return;

            Bullet bullet = InstantiateObject();
            bullet.Initialize(position, direction, owner, speed);
        }
    }
}