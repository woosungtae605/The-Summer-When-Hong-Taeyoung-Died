using Unity.VisualScripting;
using UnityEngine;

public class FlipMonster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("¥Í¿Ω");
            
            SpriteRenderer flip = collision.gameObject.GetComponent<SpriteRenderer>();
            if(flip.flipX == true)
            {
                flip.flipX = false;
                
            }
            else
            {
                flip.flipX = true;
            }
                
        }
    }
}
