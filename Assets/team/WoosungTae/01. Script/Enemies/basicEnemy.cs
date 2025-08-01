using Unity.Behavior;
using UnityEngine;

public class basicEnemy : Agent
{
    public BehaviorGraphAgent BtAgent { get; private set; }

    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        BtAgent = GetComponent<BehaviorGraphAgent>();
    }
}
