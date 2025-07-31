using UnityEngine;

public class EnemyWay : MonoBehaviour
{
    public float speed = 2f;                  // 이동 속도
    public Transform[] waypoints;            // 웨이포인트 배열
    private int currentWaypointIndex = 0;    // 현재 목표 웨이포인트

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // 현재 목표 웨이포인트
        Transform target = waypoints[currentWaypointIndex];

        // 목표 방향으로 이동
        transform.position = Vector2.MoveTowards(
            transform.position, 
            target.position, 
            speed * Time.deltaTime
        );

        // 목표 지점 도착 확인
        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            currentWaypointIndex++;

            // 경로 끝에 도달 시 처리
            if (currentWaypointIndex >= waypoints.Length)
            {
                ReachGoal();
            }
        }
    }

    private void ReachGoal()
    {
        Debug.Log("목표 지점 도착");
        Destroy(gameObject); // 나중에 플레이어 HP 감소 등으로 대체 가능
    }
}
