using UnityEngine;

namespace View
{
    public class GameOverView : MonoBehaviour
    {
        public void Enable()
            => gameObject.SetActive(true);

        public void Disable()
            => gameObject.SetActive(false);
    }
}