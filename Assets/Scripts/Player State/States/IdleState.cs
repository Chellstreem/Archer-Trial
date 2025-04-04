using UnityEngine;

namespace PlayerState
{
    public class IdleState : IState
    {
        private readonly IStateSwitcher stateSwitcher;
        private readonly IAnimationSwitcher animationSwitcher;
        private readonly IInput input; 
        private readonly ILineDrawer lineDrawer;

        public IdleState(IStateSwitcher stateSwitcher, IAnimationSwitcher animationSwitcher,
            IInput input, ILineDrawer lineDrawer)
        {
            this.stateSwitcher = stateSwitcher;
            this.animationSwitcher = animationSwitcher;
            this.input = input;  
            this.lineDrawer = lineDrawer;
        }

        public void Enter()
        {
            Debug.Log("Entering Idle State...");
            input.Enable();
            animationSwitcher.SetAnimation("idle", true, 1f); 
            lineDrawer.ToggleTrajectoryActivation(true);
            input.OnButtonPressed += OnButtonPressed;
        }

        public void Exit()
        {
            Debug.Log("Exiting Idle State...");
            input.OnButtonPressed -= OnButtonPressed;
        }   
        
        public void OnButtonPressed()
        {
            stateSwitcher.SetState(PlayerStateType.Aim);
        }
    }
}
