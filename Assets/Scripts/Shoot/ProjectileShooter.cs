using Spine;
using Spine.Unity;
using UnityEngine;
using Zenject;

public class ProjectileShooter : IProjectileShooter
{    
    private readonly IObjectShooter shooter;    
    private readonly ITracker tracker;
    private readonly IForceInformer forceInformer;
    private readonly GameObject projectilePrefab;
    private readonly SkeletonAnimation archer;
    private readonly Bone bone;      

    public ProjectileShooter(        
        IObjectShooter shooter,        
        ITracker tracker,
        IForceInformer forceInformer,
        GameObject projectilePrefab,
        SkeletonAnimation archer, 
        [Inject(Id = "AimBone")] Bone bone)
    {
        this.shooter = shooter;        
        this.tracker = tracker;
        this.forceInformer = forceInformer;
        this.projectilePrefab = projectilePrefab;
        this.archer = archer;
        this.bone = bone;
    }    

    public void Shoot()
    {
        Vector2 boneWorldPosition = archer.transform.TransformPoint(new Vector3(bone.WorldX, bone.WorldY, 0f));
        Vector2 direction = tracker.Track(boneWorldPosition);
        shooter.ShootObject(projectilePrefab, boneWorldPosition, direction, forceInformer.CurrentForce);       
    }
}
