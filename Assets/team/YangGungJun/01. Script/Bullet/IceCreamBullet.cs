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
    public override void Ability()
    {
        
    }
}
