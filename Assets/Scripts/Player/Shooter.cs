using Spawners;
using UnityEngine;

namespace Player
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private float _speed;

        public void Shoot()
        {
            _bulletSpawner.Spawn(transform.position, transform.right, _transform, _speed, true);
        }
    }
}