using System;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class States : MonoBehaviour, IStateSwitchProvider
    {
        [SerializeField] private Game _gameState;
        [SerializeField] private GameOver _gameOverState;

        private IState _currentState;
        private Dictionary<Type, IState> _states;

        private void Awake()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(IGame)] = _gameState,
                [typeof(IGameOver)] = _gameOverState,
            };

            SwitchState<IGame>();
        }

        public void SwitchState<TState>() where TState : IState
        {
            if (_states.TryGetValue(typeof(TState), out IState state) == false)
                throw new KeyNotFoundException($"Update your {nameof(_states)} dict. {typeof(TState)} was not found.");

            _currentState?.Exit();
            _currentState = state;
            state.Occupy();
        }
    }
}