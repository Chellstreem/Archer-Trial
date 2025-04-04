using UnityEngine;

public class ShootState : IState
{
    private readonly IStateSwitcher stateSwitcher;
    private readonly IAnimationSwitcher animationSwitcher;    
    private readonly IInput input;
    private readonly IProjectileShooter shooter;

    public ShootState(IStateSwitcher stateSwitcher, IAnimationSwitcher animationSwitcher,
        ILineDrawer lineDrawer, IInput input, IProjectileShooter shooter)
    {
        this.stateSwitcher = stateSwitcher;
        this.animationSwitcher = animationSwitcher;        
        this.input = input;
        this.shooter = shooter;
    }

    public void Enter()
    {
        Debug.Log("Entering Shoot State...");
        animationSwitcher.SetAnimation("attack_finish", false, 0.5f);         
        input.Disable();
        shooter.Shoot();
        stateSwitcher.SetState(PlayerStateType.Idle);
    }

    public void Exit()
    {
        Debug.Log("Exiting Shoot State...");        
    }    
}
