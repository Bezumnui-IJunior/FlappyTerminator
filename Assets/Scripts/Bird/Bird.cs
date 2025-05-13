using UnityEngine;

namespace Bird
{
    public class Bird : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private KeyboardInput _input;

        private void OnEnable()
        {
            _input.Jumping += OnJumping;
        }

        private void OnDisable()
        {
            _input.Jumping -= OnJumping;
        }

        private void OnJumping()
        {
            _movement.Jump();
        }
    }
}