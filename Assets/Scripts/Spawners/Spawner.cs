using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable
    {
        [SerializeField] private int _size;
        [SerializeField] private T _prefab;

        private ObjectPool<T> _pool;

        protected bool IsOverflow
            => _pool.CountActive >= _size;

        private void Awake()
        {
            _pool = new ObjectPool<T>(
                () => Instantiate(_prefab),
                OnGet,
                OnRelease,
                (obj) => obj.Destroy(),
                true,
                _size,
                _size
            );
        }

        protected T InstantiateObject()
        {
            _pool.Get(out T obj);

            return obj;
        }

        private void OnGet(T obj)
        {
            obj.Enable();
            obj.Freed += Release;
        }

        private void OnRelease(T obj)
        {
            obj.Disable();
            obj.Freed -= Release;
        }

        private void Release(ISpawnable spawnable)
        {
            _pool.Release(spawnable as T);
        }
    }
}