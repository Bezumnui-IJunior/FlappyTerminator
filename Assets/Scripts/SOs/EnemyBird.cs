using System;
using Spawners;
using UnityEngine;

namespace SOs
{
    [Serializable]
    [CreateAssetMenu(fileName = "Enemy", menuName = "SO / Enemy", order = 0)]
    public class EnemyBird : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;

        private void Fire() { }
    }
}