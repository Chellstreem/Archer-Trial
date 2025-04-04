public interface IStateInitializer
{
    public void InitializeStates();
    public IState GetState(PlayerStateType playerState);
}
