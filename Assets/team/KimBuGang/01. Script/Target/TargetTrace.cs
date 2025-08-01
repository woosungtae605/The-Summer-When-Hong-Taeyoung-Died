using UnityEngine;

public class TargetTrace : MonoBehaviour
{
    private Vector2Int currentPos => new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
    private Vector2Int prevPos;

    public int moveCount;

    public int priority;

    private void Update()
    {
        if (currentPos != prevPos)
        {
            moveCount++;
            prevPos = currentPos;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector3(prevPos.x, prevPos.y, 0), 0.1f);
    }
}
