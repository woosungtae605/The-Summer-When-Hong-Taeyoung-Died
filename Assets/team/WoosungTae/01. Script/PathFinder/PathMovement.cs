using UnityEngine;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(PathAgent))]
public class PathMovement : MonoBehaviour, IComponent
{
    [SerializeField] private PathAgent pathAgent;
    [SerializeField] private int maxPathCount = 100;
    [SerializeField] private Tilemap baseTileMap;

    private Vector3[] _path;
    private int _currentPathIndex;
    private Vector3 _nextPoint;
    private int _pathCount;
    private Agent _owner;
    private AgentMover _mover;
    private Vector2 _beforePosition;

    public bool IsArrived { get; private set; }
    public bool IsPathFailed { get; private set; }
    public bool IsPathPending { get; private set; }
    public bool IsStop { get; set; }

    [SerializeField] private Transform target;

    [ContextMenu("Test path")]
    private void TestPath()
    {
        SetDestination(target.position);
    }

    public void SetReferences(Tilemap tilemap, Transform tgt)
    {
        baseTileMap = tilemap;
        target = tgt;
    }
    public void Initialize(Agent agent)
    {
        _owner = agent;
        _path = new Vector3[maxPathCount];
        _mover = _owner.GetCompo<AgentMover>();
    }
    public void SetDestination(Vector3 destination)
    {
        Vector3Int startCell = baseTileMap.WorldToCell(transform.position);
        Vector3Int endCell = baseTileMap.WorldToCell(destination);
        IsArrived = false;
        IsPathFailed = false;
        IsPathPending = true;
        _beforePosition = _owner.transform.position;


        _pathCount = pathAgent.GetPath(startCell, endCell, _path);

        if (_pathCount <= 1)
        {
            IsPathFailed = true;
        }
        else
        {
            _currentPathIndex = 0;
        }
        IsPathPending = false;
    }

    private void Update()
    {
        if (IsStop) return;
        if (_currentPathIndex >= _pathCount) return;

        if (CheckArrived() == false)
        {
            Vector2 direction = _path[_currentPathIndex] - _owner.transform.position;
            _mover.SetMovementInput(direction);
        }
        else
        {
            _mover.StopImmediately();
            Debug.Log("����");
        }
    }

    private bool CheckArrived()
    {
        Vector2 destination = _path[_currentPathIndex];
        Vector2 currentPosition = _owner.transform.position;
        Vector2 beforeDirection = (destination - _beforePosition).normalized;
        Vector2 currentDirection = (destination - currentPosition).normalized;
        _beforePosition = currentPosition;

        if (Vector2.Dot(beforeDirection, currentDirection) <= 0 || Vector2.Distance(destination, currentPosition) < 0.01f)
        {
            Debug.Log(IsArrived);
            _currentPathIndex++;
            if (_currentPathIndex > _pathCount)
                IsArrived = true;
            return IsArrived;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        if (_pathCount <= 0) return;

        for (int i = 0; i < _pathCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_path[i], 0.25f);
            Gizmos.DrawLine(_path[i], _path[i + 1]);
        }
        Gizmos.DrawSphere(_path[_pathCount - 1], 0.25f);
    }

}
