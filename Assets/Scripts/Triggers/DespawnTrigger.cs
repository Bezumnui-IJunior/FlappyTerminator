using Enemy;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public class DespawnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDespawnable despawnable))
                despawnable.Despawn();
        }
    }
}