using UnityEngine;

namespace Spawners
{
    public interface IEnemySpawner
    {
        void Spawn(Vector3 position);
    }
}