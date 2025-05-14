using System;
using Spawners;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SOs
{
    [Serializable]
    [CreateAssetMenu(fileName = "EnemyRandomSpawner", menuName = "SO / EnemySpawners / EnemyRandomSpawner", order = 0)]
    public class EnemyRandomSpawner : EnemySpawnerLogic
    {
        private const float ZPosition = 0;

        public override void Spawn(Transform transform, EnemySpawner spawner)
        {
            float x = Random.Range(MinOffset.x, MaxOffset.x);
            float y = Random.Range(MinOffset.y, MaxOffset.y);
            spawner.Spawn(transform.position + new Vector3(x, y, ZPosition));
        }
    }
}