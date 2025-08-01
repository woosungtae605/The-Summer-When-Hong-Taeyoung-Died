using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] private WayPoint[] wayPoints;

    private int _currentIdx;

    public void ResetWaypoints()
    {
        _currentIdx = 0;
    }

    public Vector3 GetNextWayPoint()
    {
        Debug.Assert(wayPoints.Length >= 1, "there must be at least one wayPoints.");
        _currentIdx = (_currentIdx + 1) % wayPoints.Length;
        return wayPoints[_currentIdx].Position;
    }
    public bool TryGetNextWayPoint(out Vector3 next)
    {
        if (wayPoints == null || wayPoints.Length == 0)
        {
            next = Vector3.zero;
            return false;
        }

        if (_currentIdx + 1 >= wayPoints.Length)
        {
            next = wayPoints[^1].Position; // 마지막을 계속 반환하거나, 필요하면 default로 처리
            return false; // 더 이상 진행할 게 없음
        }

        _currentIdx++;
        next = wayPoints[_currentIdx].Position;
        return true;
    }
}
