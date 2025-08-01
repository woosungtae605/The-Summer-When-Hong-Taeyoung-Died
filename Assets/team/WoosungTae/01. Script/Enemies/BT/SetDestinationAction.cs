using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set destination", story: "[Self] Navigate to [NextPosition]", category: "Action/Path", id: "8f86d4d7b2f46387e18a2bf7bd655203")]
public partial class SetDestinationAction : Action
{
    [SerializeReference] public BlackboardVariable<Agent> Self;
    [SerializeReference] public BlackboardVariable<Vector3> NextPosition;


    private PathMovement _pathMovement;

    protected override Status OnStart()
    {
        if(Self.Value == null)
        {
            Debug.LogError("Self is not set in SetDestinationAction");
            return Status.Failure;
        }

        _pathMovement = Self.Value.GetCompo<PathMovement>();
        if(_pathMovement == null)
        {
            Debug.LogError("PathMovement component is not found on Self in SetDestinationAction");
            return Status.Failure;
        }
        _pathMovement.SetDestination(NextPosition.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(_pathMovement.IsArrived)
        {
            return Status.Success;
        }
        return Status.Running;
    }
}

