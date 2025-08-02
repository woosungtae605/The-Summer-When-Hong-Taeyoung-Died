using System;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public Vector2Int point;
    private void OnValidate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos = new Vector2(point.x, point.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}
