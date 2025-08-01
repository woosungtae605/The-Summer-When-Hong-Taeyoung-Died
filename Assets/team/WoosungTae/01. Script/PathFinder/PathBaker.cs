using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathBaker : MonoBehaviour
{
    [SerializeField] private Tilemap groundMap;
    [SerializeField] private Tilemap obstacleMap;
    [SerializeField] private BakedDataSO bakedData;

    [SerializeField] private bool isDrawGizmo = true;
    [SerializeField] private bool isCornerCheck = true;
    [SerializeField] private Color nodeColor, edgeColor;

    [ContextMenu("Bake map data")]
    private void BakedMapData()
    {
        Debug.Assert(groundMap != null && obstacleMap != null, "Target tilemap are null or empty");
        WritePointData();
        RecordNeighbors();
        SaveIfUnityEditor();
    }

    private void SaveIfUnityEditor()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(bakedData);
        AssetDatabase.SaveAssets();
#endif
    }

    private void RecordNeighbors()
    {
        foreach (NodeData nodeData in bakedData.points)
        {
            nodeData.neighbors.Clear();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == y || x == -y) continue;
                    Vector3Int nextPoint = new Vector3Int(x, y) + nodeData.cellPosition;
                    if (bakedData.TryGetNode(nextPoint, out NodeData adjacentNode))
                    {
                        if (CheckCorner(nextPoint, nodeData.cellPosition))
                        {
                            Debug.Log("��");
                            nodeData.AddNeighbor(adjacentNode);
                        }
                    }
                }
            }
        }
    }

    private bool CheckCorner(Vector3Int nextPoint, Vector3Int currentPoint)
    {
        if (!isCornerCheck) return true;

        return CanMovePosition(new Vector3Int(nextPoint.x, currentPoint.y)) && CanMovePosition(new Vector3Int(currentPoint.x, nextPoint.y));

    }

    private void WritePointData()
    {
        bakedData.ClearPoints();
        groundMap.CompressBounds();

        BoundsInt mapBound = groundMap.cellBounds;

        // Debug.Log($"xMin : {mapBound.xMin}, xMax : {mapBound.xMax}, yMin : {mapBound.yMin}, yMax : {mapBound.yMax}");

        for (int x = mapBound.xMin; x < mapBound.xMax; x++)
        {
            for (int y = mapBound.yMin; y < mapBound.yMax; y++)
            {
                Vector3Int targetCell = new Vector3Int(x, y);
                if (CanMovePosition(targetCell))
                {
                    AddPoint(targetCell);
                }
            }
        }
    }


    private bool CanMovePosition(Vector3Int targetCell)
    {
        bool hasObstacle = obstacleMap.HasTile(targetCell);
        bool hasGround = groundMap.HasTile(targetCell);
        return hasGround && !hasObstacle;
    }
    private void AddPoint(Vector3Int targetCell)
    {
        Vector3 worldPosition = groundMap.GetCellCenterWorld(targetCell);
        bakedData.AddPoint(worldPosition, targetCell);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (isDrawGizmo == false) return;

        foreach (NodeData nodeData in bakedData.points)
        {
            Gizmos.color = nodeColor;
            Gizmos.DrawWireSphere(nodeData.worldPosition, 0.15f);

            foreach (LinkData link in nodeData.neighbors)
            {
                Gizmos.color = edgeColor;
                DrawArrowGizmo(link.startPosition, link.endPosition);
            }
        }
    }

    private void DrawArrowGizmo(Vector3 start, Vector3 end)
    {
        Vector3 direction = (end - start).normalized;
        Vector3 arrowStart = end - direction * 0.25f;
        Vector3 arrowEnd = end - direction.normalized * 0.15f;
        const float arrowSize = 0.05f;

        Vector3 pointA = arrowStart + (Quaternion.Euler(0, 0, -90) * direction) * arrowSize;
        Vector3 pointB = arrowStart + (Quaternion.Euler(0, 0, 90) * direction) * arrowSize;

        Gizmos.DrawLine(start, arrowStart);
        Gizmos.DrawLine(pointA, arrowEnd);
        Gizmos.DrawLine(pointB, arrowEnd);
        Gizmos.DrawLine(pointA, pointB);
    }
#endif
}
