using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Get next wayPoint", story: "get [nextPathPoint] from [WayPoints]", category: "Action/Path", id: "e2ee269c466489bf8d5bd3c00cf5a8a6")]
public partial class GetNextWayPointAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector3> NextPathPoint;
    [SerializeReference] public BlackboardVariable<WayPoints> WayPoints;

    protected override Status OnStart()
    {
        NextPathPoint.Value = WayPoints.Value.GetNextWayPoint();
        return Status.Success;
    }
}

