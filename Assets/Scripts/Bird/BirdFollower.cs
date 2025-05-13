using System;
using UnityEngine;

namespace Bird
{
    public class BirdFollower : MonoBehaviour
    {
        [SerializeField] private Bird _bird;

        private void Update()
        {
            Vector3 position = transform.position;
            position.x = _bird.transform.position.x;
            transform.position = position;
        }
    }
}