using Misc;
using UnityEngine;

namespace States
{
    public class Freezer : MonoBehaviour, IResetable
    {
        private bool _isInit;
        private float _timescale;

        public void Reset()
        {
            if (_isInit)
                return;

            _isInit = true;
            _timescale = Time.timeScale;
        }

        [ContextMenu("Freeze")]
        public void Freeze()
        {
            Time.timeScale = 0;
        }

        [ContextMenu("Unfreeze")]
        public void Unfreeze()
        {
            Time.timeScale = _timescale;
        }
    }
}