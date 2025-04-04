using UnityEngine;

public interface ILineDrawer
{
    public void DrawTrajectory(Vector2 startPoint);
    public void ToggleTrajectoryActivation(bool isEnabled);
}
