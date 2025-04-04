using Spine;
using Spine.Unity;
using UnityEngine;
using Zenject;

public class TrajectoryLineHandler : MonoBehaviour
{
    private ILineDrawer lineDrawer;
    private SkeletonAnimation skeletonAnimation;           
    private Bone aimBone;

    [Inject]
    public void Constrcut(
        ILineDrawer lineDrawer,
        SkeletonAnimation skeletonAnimation,
        [Inject(Id = "AimBone")] Bone aimBone)
    {
        this.lineDrawer = lineDrawer; 
        this.skeletonAnimation = skeletonAnimation;
        this.aimBone = aimBone;       
    }

    private void Update()
    {
        Vector2 boneWorldPosition = skeletonAnimation.transform.TransformPoint(new Vector3(aimBone.WorldX, aimBone.WorldY, 0f));
        lineDrawer.DrawTrajectory(boneWorldPosition);             
    }
}
