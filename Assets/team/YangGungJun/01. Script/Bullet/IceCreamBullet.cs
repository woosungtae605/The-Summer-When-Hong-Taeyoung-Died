using UnityEngine;

public class IceCreamBullet : Bullet
{
    [SerializeField] string name;
    [SerializeField] Rigidbody2D rb;
    private void OnEnable()
    {
        rb.linearVelocityX = 3;
    }
    private void OnDisable()
    {
        rb.linearVelocityX = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Monster>(out Monster monster))
        {

        }
    }
    public override void Ability()
    {
        
    }
}
