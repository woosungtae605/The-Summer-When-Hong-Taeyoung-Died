using UnityEngine;

public class FlipMonster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            SpriteRenderer flip = collision.gameObject.GetComponent<SpriteRenderer>();
            if(flip.flipX == false)
                flip.flipX = true;

            if (flip.flipX == true)
                flip.flipX = false;
        }
    }
}
