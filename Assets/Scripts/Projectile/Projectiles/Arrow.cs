using UnityEngine;

public class Arrow : Projectile
{
    protected override void OnCollision(Collision2D collision)
    {
        Debug.Log($"Попал в {collision.gameObject.name}");        
    }
}
