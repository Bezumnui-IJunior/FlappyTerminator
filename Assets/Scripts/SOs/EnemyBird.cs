using System;
using UnityEngine;

namespace SOs
{
    [Serializable]
    [CreateAssetMenu(fileName = "Enemy", menuName = "SO / Enemy", order = 0)]
    public class EnemyBird : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _minShootDelay = 0.5f;
        [SerializeField] private float _maxShootDelay = 2f;
        public float Speed => _speed;
        public float BulletSpeed => _bulletSpeed;
        public float MinShootDelay => _minShootDelay;
        public float MaxShootDelay => _maxShootDelay;
    }
}