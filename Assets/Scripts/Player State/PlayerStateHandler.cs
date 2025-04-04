using Zenject;

namespace PlayerState
{
    public class PlayerStateHandler : IInitializable
    {
        private readonly IStateInitializer stateInitializer;
        private readonly IStateSwitcher stateSwitcher;

        public PlayerStateHandler(IStateInitializer stateInitializer, IStateSwitcher stateSwitcher)
        {
            this.stateInitializer = stateInitializer;
            this.stateSwitcher = stateSwitcher;
        }

        public void Initialize()
        {
            stateInitializer.InitializeStates();
            stateSwitcher.SetState(PlayerStateType.Idle);
        }
    }
}
