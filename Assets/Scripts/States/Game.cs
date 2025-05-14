using System.Collections.Generic;
using Attributes;
using Misc;
using UnityEngine;
using Object = UnityEngine.Object;

namespace States
{
    public class Game : State, IGame
    {
        [SerializeField] private Freezer _freezer;
        [SerializeField] private Player.Player _player;

        [SerializeField] [Restrict(typeof(IResetable))]
        private List<Object> _resetObjects;

        public void Occupy()
        {
            foreach (Object obj in _resetObjects)
            {
                if (obj is IResetable resetable)
                    resetable.Reset();
            }

            _freezer.Unfreeze();
            _player.Died += OnPlayerDied;
        }

        public void Exit()
        {
            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            ChangeState<IGameOver>();
        }
    }
}