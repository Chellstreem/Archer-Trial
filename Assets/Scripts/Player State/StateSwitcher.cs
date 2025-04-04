using System.Collections.Generic;

namespace PlayerState
{
    public class StateSwitcher : IStateSwitcher
    {
        private readonly IStateInitializer stateInitializer;
        private IState currentState;
        private PlayerStateType currentStateName;
        public IState CurrentState => currentState;

        private readonly Dictionary<PlayerStateType, HashSet<PlayerStateType>> allowedTransitions =
        new Dictionary<PlayerStateType, HashSet<PlayerStateType>>
        {
        { PlayerStateType.Idle, new HashSet<PlayerStateType> { PlayerStateType.Move, PlayerStateType.Aim } },
        { PlayerStateType.Move, new HashSet<PlayerStateType> { PlayerStateType.Idle, PlayerStateType.Aim } },
        { PlayerStateType.Aim, new HashSet<PlayerStateType> { PlayerStateType.Shoot, PlayerStateType.Idle, PlayerStateType.Move }},
        { PlayerStateType.Shoot, new HashSet<PlayerStateType> { PlayerStateType.Move, PlayerStateType.Idle }}
        };
        public StateSwitcher(IStateInitializer stateInitializer)
        {
            this.stateInitializer = stateInitializer;
        }

        public void SetState(PlayerStateType newState)
        {
            if (CanTransitionTo(newState))
            {
                currentState?.Exit();
                currentState = stateInitializer.GetState(newState);
                currentStateName = newState;

                currentState.Enter();
            }
        }

        private bool CanTransitionTo(PlayerStateType state)
        {
            if (currentState == null)
                return true;

            if (allowedTransitions.TryGetValue(currentStateName, out var possibleTransitions))
            {
                return possibleTransitions.Contains(state);
            }

            return false;
        }
    }
}

