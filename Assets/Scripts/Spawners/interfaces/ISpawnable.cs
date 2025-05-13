using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Spawners
{
    public interface ISpawnable
    {
        protected GameObject GameObject { get; }

        public event Action<ISpawnable> Freed;

        void Enable()
            => GameObject.SetActive(true);

        void Disable()
            => GameObject.SetActive(false);

        void Destroy()
            => Object.Destroy(GameObject);
    }
}