using System.Collections.Generic;
using Misc;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class Spawner<T> : MonoBehaviour, IResetable where T : MonoBehaviour, ISpawnable
    {
        [SerializeField] private int _size;
        [SerializeField] private T _prefab;

        private ObjectPool<T> _pool;
        private readonly List<T> _spawned = new List<T>();

        protected bool IsOverflow
            => _pool.CountActive >= _size;

        private void Awake()
        {
            _pool = new ObjectPool<T>(
                () => Instantiate(_prefab),
                OnGet,
                OnRelease,
                obj => obj.Destroy(),
                true,
                _size,
                _size
            );
        }

        public void Reset()
        {
            for (int i = _spawned.Count - 1; i >= 0; i--) Release(_spawned[i]);
        }

        protected T InstantiateObject()
        {
            _pool.Get(out T obj);

            return obj;
        }

        private void OnGet(T obj)
        {
            obj.gameObject.SetActive(true);
            obj.Freed += Release;
            _spawned.Add(obj);
        }

        private void OnRelease(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.Freed -= Release;
            _spawned.Remove(obj);
        }

        private void Release(ISpawnable spawnable)
        {
            _pool.Release(spawnable as T);
        }
    }
}