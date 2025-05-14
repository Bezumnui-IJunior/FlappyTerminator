using Misc;
using Player;
using SOs;
using Spawners;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public class SpawnTrigger : MonoBehaviour, IResetable
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Transform _transform;
        [SerializeField] private EnemySpawnerLogic _spawnerLogic;
        [SerializeField] private Vector3 _respawnOffset;

        private Vector3 _initialPosition;
        private bool _isInit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<IPlayer>() == null)
                return;

            _spawnerLogic.Spawn(_transform, _enemySpawner);
            Respawn();
        }

        public void Reset()
        {
            if (_isInit == false)
                _transform.position = _initialPosition;

            _transform.position = _initialPosition;
            _isInit = true;
        }

        private void Respawn()
        {
            _transform.position += _respawnOffset;
        }
    }
}