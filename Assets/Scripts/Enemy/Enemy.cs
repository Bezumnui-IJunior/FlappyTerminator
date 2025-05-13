using System;
using SOs;
using Spawners;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, ISpawnable
    {
        [SerializeField] private EnemyBird _scriptable;
        [SerializeField] private BulletSpawner _bulletSpawner;

        private IBulletSpawner BulletSpawner => _bulletSpawner;
        GameObject ISpawnable.GameObject => gameObject;

        public event Action<ISpawnable> Freed;

        private void Update()
        {
            transform.Translate(Vector3.right * (_scriptable.Speed * Time.deltaTime));
            // BulletSpawner
            BulletSpawner.Spawn(transform.position);
        }

        private void Free()
            => Freed?.Invoke(this);
    }
}