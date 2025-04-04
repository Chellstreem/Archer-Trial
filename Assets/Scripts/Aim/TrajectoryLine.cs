using UnityEngine;
using Spine;
using Spine.Unity;

namespace Aim
{
    public class TrajectoryLine : ILineDrawer
    {
        private readonly ITracker tracker;
        private readonly LineRenderer lineRenderer;        

        private readonly int positionCount = 2;
        private readonly float length = 5f;

        public TrajectoryLine(ITracker tracker, LineRenderer lineRenderer)
        {
            this.tracker = tracker;
            this.lineRenderer = lineRenderer;            
            lineRenderer.positionCount = positionCount;
        }

        public void DrawTrajectory(Vector2 startPoint)
        {            
            if (startPoint == null) return;
            
            Vector2 direction = tracker.Track(startPoint);
            Vector2 startPosition = startPoint;
            Vector2 endPosition = startPosition + direction * length;

            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
        }

        public void ToggleTrajectoryActivation(bool isEnabled)
        {
            lineRenderer.enabled = isEnabled;
        }
    }
}
