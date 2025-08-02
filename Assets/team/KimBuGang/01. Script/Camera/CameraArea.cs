using System;
using UnityEngine;

public class CameraArea : MonoBehaviour
{
    public Vector2 center;
    public Vector2 mapSize;

    private float height;
    private float width;

    void Start()
    {
        center = new Vector2(transform.position.x, transform.position.y);
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void LateUpdate()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
        LimitCameraArea();
    }

    void LimitCameraArea()
    {

        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
