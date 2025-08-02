using System;
using UnityEngine;

public class AgentMover : MonoBehaviour, IComponent
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private Monster monster;
    private Agent _owner;
    private Vector2 _movementInput;

    public Action<Vector2> OnSpeedChange;
    public void Initialize(Agent agent)
    {
        _owner = agent;
    }

    public void StopImmediately()
    {
        _movementInput = Vector2.zero;
        rigidbody.linearVelocity = Vector2.zero;
    }

    public void SetMovementInput(Vector2 input)
    {
        _movementInput = input.normalized;
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = _movementInput * moveSpeed;
        moveSpeed = monster.speed;
        OnSpeedChange?.Invoke(rigidbody.linearVelocity);
    }
}
