using System;
using Spawners;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SOs
{
    [Serializable]
    [CreateAssetMenu(fileName = "EnemiesMultiSpawner",
        menuName = "SO / EnemySpawners / EnemiesMultiSpawner",
        order = 0)]
    public class EnemiesMultiSpawner : EnemyRandomSpawner
    {
        [SerializeField] private int _minCount;
        [SerializeField] private int _maxCount;

        public override void Spawn(Transform transform, EnemySpawner spawner)
        {
            int count = Random.Range(_minCount, _maxCount + 1);

            for (int i = 0; i < count; i++) base.Spawn(transform, spawner);
        }
    }
}