using UnityEngine;

public class NomalBullet : Bullet
{
    [SerializeField] string name;
    [SerializeField] Rigidbody2D rb;
    [Header("µ¥¹ÌÁö")]
    [SerializeField] int dmg;
    private void OnEnable()
    {
        base.OnEnable();
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
            monster.SetHP(dmg);
        }
    }
    public override void Ability()
    {

    }
}
