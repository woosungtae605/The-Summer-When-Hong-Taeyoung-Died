using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PathAgent : MonoBehaviour
{
    [SerializeField] private BakedDataSO bakedData;

    private PriorityQueue<AstarNode> _openList = new PriorityQueue<AstarNode>();
    private List<AstarNode> _closeList = new List<AstarNode>();
    private List<AstarNode> _path = new List<AstarNode>();


    public int GetPath(Vector3Int startPosition, Vector3Int destination, Vector3[] pointArr)
    {
        if (CalculatePath(startPosition, destination))
        {
            for (int i = 0; i < _path.Count; i++)
            {
                pointArr[i] = _path[i].worldPosition;
            }
            return _path.Count;
        }

        return 0;
    }

    private bool CalculatePath(Vector3Int startPosition, Vector3Int destination)
    {
        _openList.Clear();
        _closeList.Clear();
        _path.Clear();

        bool result = false;
        if (bakedData.TryGetNode(startPosition, out NodeData startNode) == false)
            return false;

        if (bakedData.TryGetNode(destination, out NodeData endNode) == false)
            return false;

        _openList.Push(new AstarNode
        {
            nodeData = startNode,
            cellPosition = startNode.cellPosition,
            worldPosition = startNode.worldPosition

        });

        while (_openList.Count > 0)
        {
            AstarNode currentNode = _openList.Pop(); //가장 비용이 작은 녀석을 가져온다

            foreach (LinkData link in currentNode.nodeData.neighbors)
            {
                bool isVisited = _closeList.Any(node => node.cellPosition == link.endCellPosition);
                if (isVisited) continue;

                if (bakedData.TryGetNode(link.endCellPosition, out NodeData nextNode) == false)
                    continue;

                float newG = link.cost + currentNode.G;

                AstarNode nextAstarNode = new AstarNode
                {
                    nodeData = nextNode,
                    cellPosition = nextNode.cellPosition,
                    worldPosition = nextNode.worldPosition,
                    parent = currentNode,
                    G = newG,
                    F = newG + CalcH(nextNode.cellPosition, endNode.cellPosition)
                };

                AstarNode existInOpenList = _openList.Contains(nextAstarNode);
                if (existInOpenList != null)
                {
                    if (nextAstarNode.G < existInOpenList.G)
                    {
                        existInOpenList.G = nextAstarNode.G;
                        existInOpenList.F = nextAstarNode.F;
                        existInOpenList.parent = nextAstarNode.parent;
                    }
                }
                else
                {
                    _openList.Push(nextAstarNode);
                }
            }

            _closeList.Add(currentNode);

            if (currentNode.nodeData == endNode)
            {
                result = true;
                break;
            }
        }

        if (result)
        {
            AstarNode last = _closeList[^1];
            while (last.parent != null)
            {
                _path.Add(last);
                last = last.parent;
            }
            _path.Add(last);
            _path.Reverse();
        }
        return result;

    }

    private float CalcH(Vector3Int startCellPosition, Vector3Int endCellPosiiton) => Vector3Int.Distance(startCellPosition, endCellPosiiton);
}

