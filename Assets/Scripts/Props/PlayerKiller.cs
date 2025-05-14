using Player;
using UnityEngine;

namespace Props
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerKiller : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IPlayer player))
                player.Die();
        }
    }
}