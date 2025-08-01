using UnityEngine;

public class RollBackEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
        }
    }
}
