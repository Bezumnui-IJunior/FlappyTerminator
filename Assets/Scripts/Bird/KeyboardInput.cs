using System;
using UnityEngine;

namespace Bird
{
    public class KeyboardInput : MonoBehaviour, IInput
    {
        private const KeyCode JumpKey = KeyCode.Space;
        private const KeyCode ShootKey = KeyCode.Return;

        public event Action Jumping;
        public event Action Shoot;

        private void Update()
        {
            if (Input.GetKeyDown(JumpKey))
                Jumping?.Invoke();

            if (Input.GetKeyDown(ShootKey))
                Shoot?.Invoke();
        }
    }
}