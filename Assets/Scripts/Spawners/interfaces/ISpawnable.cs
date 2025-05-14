using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Spawners
{
    public interface ISpawnable
    {
        // ReSharper disable once InconsistentNaming
        public GameObject gameObject { get; }

        public event Action<ISpawnable> Freed;

        void Destroy()
            => Object.Destroy(gameObject);
    }
}