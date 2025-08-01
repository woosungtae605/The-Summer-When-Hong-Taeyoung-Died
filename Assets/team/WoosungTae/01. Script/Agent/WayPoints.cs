using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] private WayPoint[] wayPoints;

    private int _currentIdx;

    public Vector3 GetNextWayPoint()
    {
        Debug.Assert(wayPoints.Length >= 1, "there must be at least one wayPoints.");
        _currentIdx = (_currentIdx + 1) % wayPoints.Length;
        return wayPoints[_currentIdx].Position;
    }
}
