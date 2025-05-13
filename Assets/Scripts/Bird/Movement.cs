using UnityEngine;

namespace Bird
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce = 5;
        [SerializeField] private float _horizontalSpeed = 1f;

        private void Update()
        {
            transform.Translate(Vector3.right * (_horizontalSpeed * Time.deltaTime));
        }

        public void Jump()
        {
            _rigidbody.linearVelocityY = _jumpForce;
        }
    }
}