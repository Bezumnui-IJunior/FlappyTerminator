using UnityEngine;

namespace Bird
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _minZ = -40;
        [SerializeField] private float _maxZ = 40;

        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Awake()
        {
            _minRotation = Quaternion.Euler(0, 0, _minZ);
            _maxRotation = Quaternion.Euler(0, 0, _maxZ);
        }

        private void Update()
        {
            Quaternion destination = _maxRotation;

            if (_rigidbody.linearVelocityY > 0)
                destination = _minRotation;
            
            float delta = Mathf.Abs(_rigidbody.linearVelocityY) * _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, destination, delta);
        }

    }
}