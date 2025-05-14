using Attributes;
using UnityEngine;

namespace States
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] [Restrict(typeof(IStateSwitchProvider))]
        private Object _stateSwitch;

        private IStateSwitchProvider StateSwitch => _stateSwitch as IStateSwitchProvider;

        protected void ChangeState<TState>() where TState : IState
        {
            StateSwitch.SwitchState<TState>();
        }
    }
}