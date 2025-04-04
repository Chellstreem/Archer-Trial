using UnityEngine;
using UnityEngine.InputSystem;

namespace Aim
{
    public class Tracker : ITracker
    {
        private readonly Camera mainCamera;

        public Tracker(Camera mainCamera)
        {
            this.mainCamera = mainCamera;
        }

        public Vector2 Track(Vector2 weaponPosition)
        {
            if (Mouse.current == null)
                return Vector2.zero;

            Vector2 screenPosition = Mouse.current.position.ReadValue();
            Vector2 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
            return (worldPosition - weaponPosition).normalized;
        }
    }
}
