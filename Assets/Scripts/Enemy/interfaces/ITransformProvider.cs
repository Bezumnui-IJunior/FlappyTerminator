using UnityEngine;

namespace Enemy
{
    public interface ITransformProvider
    {
        // ReSharper disable once InconsistentNaming
        public Transform transform { get; }
    }
}