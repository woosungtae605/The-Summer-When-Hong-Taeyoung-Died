using UnityEngine;

public class NomalBullet : Bullet
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
        Instantiate(gameObject);
    }
}
