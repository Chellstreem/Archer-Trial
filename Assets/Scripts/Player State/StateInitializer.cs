using System.Collections.Generic;
using Zenject;

namespace PlayerState
{
    public class StateInitializer : IStateInitializer
    {
        private readonly DiContainer container;
        private Dictionary<PlayerStateType, IState> stateMap;

        public StateInitializer(DiContainer container)
        {
            this.container = container;
        }

        public void InitializeStates()
        {
            stateMap = new Dictionary<PlayerStateType, IState>()
            {
                { PlayerStateType.Idle, container.Resolve<IdleState>() },
                { PlayerStateType.Aim, container.Resolve<AimState>() },
                { PlayerStateType.Shoot, container.Resolve<ShootState>() }
            };
        }

        public IState GetState(PlayerStateType stateType)
        {
            return stateMap.TryGetValue(stateType, out IState state) ? state : null;
        }
    }
}
