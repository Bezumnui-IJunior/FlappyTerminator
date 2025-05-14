using Spawners;
using UnityEngine;

namespace SOs
{
    public abstract class EnemySpawnerLogic : ScriptableObject
    {
        [SerializeField] private Vector2 _minOffset;
        [SerializeField] private Vector2 _maxOffset;

        protected Vector2 MinOffset => _minOffset;
        protected Vector2 MaxOffset => _maxOffset;

        public abstract void Spawn(Transform transform, EnemySpawner spawner);
    }
}