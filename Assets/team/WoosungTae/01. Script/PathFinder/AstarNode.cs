using System;
using UnityEngine;

public class AstarNode : IComparable<AstarNode>
{
    public Vector3 worldPosition;
    public Vector3Int cellPosition;
    public NodeData nodeData;

    public AstarNode parent;

    public float G;
    public float F;

    public int CompareTo(AstarNode other)
    {
        if (Mathf.Approximately(other.F, F)) return 0;

        return other.F < F ? -1 : 1;
    }

    public override bool Equals(object obj)
    {
        if (obj is AstarNode astarNode)
        {
            if (astarNode is null) return false;
            return astarNode.cellPosition == cellPosition;
        }

        return false;
    }
    public override int GetHashCode() => cellPosition.GetHashCode();

    public static bool operator ==(AstarNode lhs, AstarNode rhs)
    {
        if (lhs is null)
        {
            if (rhs is null) return true;
            return false;
        }

        return lhs.Equals(rhs);
    }

    public static bool operator !=(AstarNode lhs, AstarNode rhs)
    {
        return !(lhs == rhs);
    }
}