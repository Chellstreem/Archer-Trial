public interface IStateSwitcher
{
    public IState CurrentState { get; }
    public void SetState(PlayerStateType stateType);
}
