using UnityEngine;

namespace PlayerState
{
    public class AimState : IState
    {
        private readonly IStateSwitcher stateSwitcher;
        private readonly IAnimationSwitcher animationSwitcher;
        private readonly IInput input;

        public AimState(IStateSwitcher stateSwitcher, IAnimationSwitcher animationSwitcher, IInput input)
        {
            this.stateSwitcher = stateSwitcher;
            this.animationSwitcher = animationSwitcher;
            this.input = input;
        }

        public void Enter()
        {
            Debug.Log("Entering Aim State...");
            animationSwitcher.SetAnimation("attack_start", false, 1.5f);
            input.OnButtonReleased += OnButtonReleased;
        }

        public void Exit()
        {
            Debug.Log("Exiting Aim State...");
            input.OnButtonReleased -= OnButtonReleased;            
        }

        private void OnButtonReleased()
        {
            stateSwitcher.SetState(PlayerStateType.Shoot);            
        }
    }
}
