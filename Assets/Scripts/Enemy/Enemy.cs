using System;
using Misc;
using Props;
using SOs;
using Spawners;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Enemy : MonoBehaviour, ISpawnable, IDespawnable, ICoroutineExecutor, ITransformProvider,
        IBulletAcceptor
    {
        [SerializeField] private EnemyBird _scriptable;
        private Shooter _shooter;

        public event Action<ISpawnable> Freed;

        private void Update()
        {
            transform.Translate(Vector3.right * (_scriptable.Speed * Time.deltaTime));
        }

        private void OnDisable()
        {
            _shooter?.StopShooting();
        }

        public void AcceptBullet()
            => Despawn();

        public void Despawn()
        {
            Freed?.Invoke(this);
        }

        public void Initialize(Vector3 position, IBulletSpawner bulletSpawner)
        {
            transform.position = position;

            _shooter = new Shooter(this,
                this,
                bulletSpawner,
                Random.Range(_scriptable.MinShootDelay, _scriptable.MaxShootDelay),
                _scriptable.BulletSpeed
            );

            _shooter?.StartShooting();
        }
    }
}