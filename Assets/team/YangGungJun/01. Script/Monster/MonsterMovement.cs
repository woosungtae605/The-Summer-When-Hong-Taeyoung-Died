using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public MonsterSO monsterSO;

    [field: SerializeField] public float speed { get; private set; }
    [SerializeField] private Vector3 MoveDir = Vector3.zero;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        speed = monsterSO.speed;
    }
    private void Update()
    {
        rb.linearVelocity = MoveDir * speed * Time.deltaTime;
    }
    public void SetMoveDir(Vector3 direction)
    {
        MoveDir = direction;
    }
}
