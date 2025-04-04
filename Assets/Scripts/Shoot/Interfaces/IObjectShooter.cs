using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectShooter
{
    public void ShootObject(GameObject shootObj, Vector2 startPosition, Vector2 direction, float force);
}
