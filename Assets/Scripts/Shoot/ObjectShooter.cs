using Spine;
using Spine.Unity;
using UnityEngine;
using Zenject;

namespace Shoot
{
    public class ObjectShooter : IObjectShooter
    {
        private readonly Bone bone;        
        private readonly SkeletonAnimation archer;

        public ObjectShooter( [Inject(Id = "AimBone")] Bone bone, SkeletonAnimation archer)
        {
            this.bone = bone;            
            this.archer = archer;
        }

        public void ShootObject(GameObject shootObj, Vector2 startPosition, Vector2 direction, float force)
        {
            if (shootObj == null) return;
            

            GameObject projectile = Object.Instantiate(shootObj, startPosition, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
            }
        }
    }
}
