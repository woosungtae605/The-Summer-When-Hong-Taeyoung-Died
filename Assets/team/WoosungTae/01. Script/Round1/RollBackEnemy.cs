using UnityEngine;

public class RollBackEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            Monster check = collision.gameObject.GetComponent<Monster>();
            SpawnManager.instance.EnemyReturn(check.GetNumber(), collision.gameObject);
        }
    }
}
