using System;
using Bird;
using Spawners;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour, ISpawnable
    {
        [SerializeField] private float _speed;
        GameObject ISpawnable.GameObject => gameObject;

        public event Action<ISpawnable> Freed;

        private void Update()
        {
            transform.Translate(Vector3.left * (_speed * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IBulletAcceptor acceptor) == false)
                return;

            acceptor.AcceptBullet();
            Free();
        }

        [ContextMenu("Return to the Pool")]
        private void Free()
            => Freed?.Invoke(this);
    }
}