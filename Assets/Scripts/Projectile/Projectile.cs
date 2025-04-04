using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : MonoBehaviour
{
    protected abstract void OnCollision(Collision2D collision);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);        
    }
}
