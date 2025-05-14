using System;
using Misc;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IPlayer, IResetable
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private KeyboardInput _input;
        [SerializeField] private Shooter _shooter;
        [SerializeField] private Rotator _rotator;

        private Vector3 _initialPosition;

        public event Action Died;

        private void Awake()
        {
            _initialPosition = transform.position;
        }

        private void OnEnable()
        {
            _input.Jumping += OnJumping;
            _input.Shoot += OnShoot;
        }

        private void OnDisable()
        {
            _input.Jumping -= OnJumping;
            _input.Shoot -= OnShoot;
        }

        public void AcceptBullet()
            => Die();

        public void Die()
            => Died?.Invoke();

        public void Reset()
        {
            transform.position = _initialPosition;
            _movement.Reset();
            _rotator.Reset();
        }

        private void OnJumping()
            => _movement.Jump();

        private void OnShoot()
            => _shooter.Shoot();
    }
}