using UnityEngine;

namespace Spawners
{
    public interface IBulletSpawner
    {
        void Spawn(Vector3 position, Vector3 direction, Transform owner, float speed, bool enforce = false);
    }
}