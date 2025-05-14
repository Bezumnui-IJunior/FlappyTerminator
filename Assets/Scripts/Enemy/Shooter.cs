using Misc;
using Spawners;
using UnityEngine;

namespace Enemy
{
    public class Shooter
    {
        private readonly IBulletSpawner _bulletSpawner;
        private readonly float _bulletSpeed;
        private readonly CooldownTimer _timer;
        private readonly ITransformProvider _transformProvider;

        public Shooter(ICoroutineExecutor executor, ITransformProvider transformProvider, IBulletSpawner bulletSpawner,
            float delaySeconds, float bulletSpeed)
        {
            _timer = new CooldownTimer(executor, delaySeconds);
            _timer.Freed += Shooting;
            _transformProvider = transformProvider;
            _bulletSpawner = bulletSpawner;
            _bulletSpeed = bulletSpeed;
        }

        private Transform Transform => _transformProvider.transform;

        public void StartShooting()
        {
            _timer.Start();
        }

        public void StopShooting()
        {
            _timer.Stop();
        }

        private void Shooting()
        {
            _bulletSpawner.Spawn(Transform.position, Transform.right, Transform, _bulletSpeed);
            StartShooting();
        }
    }
}