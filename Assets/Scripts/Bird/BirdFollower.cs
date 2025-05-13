using UnityEngine;

namespace Bird
{
    public class BirdFollower : MonoBehaviour
    {
        [SerializeField] private Bird _bird;

        private float _offsetX;

        private void Awake()
        {
            _offsetX = transform.position.x -  _bird.transform.position.x;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            position.x = _bird.transform.position.x + _offsetX;
            transform.position = position;
        }
    }
}