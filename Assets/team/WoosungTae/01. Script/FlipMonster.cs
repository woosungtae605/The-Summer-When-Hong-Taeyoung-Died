using UnityEngine;

public class FlipMonster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("����");
            SpriteRenderer flip = collision.gameObject.GetComponent<SpriteRenderer>();
                flip.flipX = true;
        }
    }
}
