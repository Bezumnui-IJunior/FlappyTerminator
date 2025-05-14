using UnityEngine;

namespace Player
{
    public class BirdFollower : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private float _offsetX;

        private void Awake()
        {
            _offsetX = transform.position.x - _player.transform.position.x;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            position.x = _player.transform.position.x + _offsetX;
            transform.position = position;
        }
    }
}