using UnityEngine;

public class EnemyWay : MonoBehaviour
{
    private Monster monster;
    private Rigidbody2D rb;

    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Awake()
    {
        monster = GetComponent<Monster>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveWithVelocity();
    }

    private void MoveWithVelocity()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];//타겟
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * monster.monsterSO.speed;

        // 목표에 도달했는지 확인
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;

            // 다음 웨이포인트로 계속 진행
            if (currentWaypointIndex >= waypoints.Length)//도착했는지 확인
            {
                ReachGoal();
            }
        }
    }

    private void ReachGoal()
    {
        rb.linearVelocity = Vector2.zero;
        Debug.Log($"{monster.monsterSO.name}도착");
    }
}