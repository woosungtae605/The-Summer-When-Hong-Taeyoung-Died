using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePostion = Input.mousePosition;

        Vector3 worldPostion = Camera.main.ScreenToWorldPoint(mousePostion);

        transform.position = new Vector3(worldPostion.x, worldPostion.y, 0);
    }
}
