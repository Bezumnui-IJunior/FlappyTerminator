using System;
using Enemy;
using Spawners;
using UnityEngine;

namespace Props
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour, ISpawnable, IDespawnable
    {
        private Vector3 _direction;
        private Transform _owner;
        private float _speed;

        public event Action<ISpawnable> Freed;

        private void Update()
        {
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IBulletAcceptor acceptor) == false)
                return;

            if (other.transform == _owner)
                return;

            acceptor.AcceptBullet();
            Despawn();
        }

        public void Despawn()
        {
            Freed?.Invoke(this);
        }

        public void Initialize(Vector3 position, Vector3 direction, Transform owner, float speed)
        {
            _direction = direction;
            transform.position = position;
            _owner = owner;
            _speed = speed;
        }
    }
}