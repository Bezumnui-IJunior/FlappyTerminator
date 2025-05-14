namespace States
{
    public interface IStateSwitchProvider
    {
        public void SwitchState<TState>() where TState : IState;
    }
}