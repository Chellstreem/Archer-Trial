using PlayerState;
using Spine.Unity;
using UnityEngine;
using Zenject;
using Animation;
using Aim;
using Spine;
using Shoot;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SkeletonAnimation archer;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private CoroutineRunner coroutineRunner;

    [SpineBone(dataField: nameof(archer))]
    [SerializeField] private string rotationBone;
    [SpineBone(dataField: nameof(archer))]
    [SerializeField] private string aimBone;

    public override void InstallBindings()
    {
        Container.Bind<Camera>()
            .FromInstance(mainCamera)
            .AsSingle();

        Container.Bind<SkeletonAnimation>()
            .FromInstance(archer)
            .AsSingle();

        Container.Bind<LineRenderer>()
            .FromInstance(lineRenderer)
            .AsSingle(); 
        
        Container.Bind<GameObject>()
            .FromInstance(projectilePrefab)
            .AsSingle();

        Container.Bind<Bone>()
            .WithId("RotationBone")
            .To<Bone>()
            .FromInstance(archer.Skeleton.FindBone(rotationBone))
            .AsTransient();

        Container.Bind<Bone>()
            .WithId("AimBone")
            .To<Bone>()
            .FromInstance(archer.Skeleton.FindBone(aimBone))
            .AsTransient();

        Container.Bind<ICoroutineRunner>().To<ICoroutineRunner>()
            .FromInstance(coroutineRunner)
            .AsSingle();

        InstallPlayerStates();
        InstallAnimation();
        InstallAim();
        
        Container.Bind<IInput>().To<DesktopInput>().AsSingle();
        Container.Bind<IObjectShooter>().To<ObjectShooter>().AsSingle();
        Container.BindInterfacesTo<ProjectileShooter>().AsSingle().NonLazy();
        Container.Bind<IForceInformer>().To<ForceReader>().AsSingle().NonLazy();
    }

    private void InstallPlayerStates()
    {
        Container.Bind<IdleState>().AsSingle().NonLazy();
        Container.Bind<AimState>().AsSingle().NonLazy();
        Container.Bind<ShootState>().AsSingle().NonLazy();
        Container.Bind<IStateInitializer>().To<StateInitializer>().AsSingle();
        Container.Bind<IStateSwitcher>().To<StateSwitcher>().AsSingle();
        Container.Bind<IInitializable>().To<PlayerStateHandler>().AsSingle().NonLazy();
    }

    private void InstallAnimation()
    {
        Container.Bind<IAnimationSwitcher>().To<AnimationSwitcher>().AsSingle();
    }

    private void InstallAim()
    {
        Container.Bind<ITracker>().To<Tracker>().AsSingle();
        Container.Bind<ILineDrawer>().To<TrajectoryLine>().AsSingle();
    }    
}
