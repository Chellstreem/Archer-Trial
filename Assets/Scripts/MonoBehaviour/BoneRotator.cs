using Spine;
using Spine.Unity;
using UnityEngine;
using Zenject;

public class BoneRotator : MonoBehaviour
{
    private ITracker tracker;
    private SkeletonAnimation archer;
    private Bone rotationBone;

    [Inject]
    public void Construct(ITracker tracker, SkeletonAnimation skeletonAnimation,
        [Inject(Id = "RotationBone")] Bone rotationBone)
    {
        this.tracker = tracker;
        archer = skeletonAnimation;
        this.rotationBone = rotationBone;
    }

    private void Update()
    {
        Vector2 boneWorldPosition = archer.transform.TransformPoint(
            new Vector3(rotationBone.WorldX, rotationBone.WorldY, 0f));

        Vector2 direction = tracker.Track(boneWorldPosition);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotationBone.Rotation = angle;
    }
}
