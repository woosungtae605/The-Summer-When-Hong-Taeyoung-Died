using UnityEngine;

public class IceCreamBullet : Bullet
{
    [SerializeField] string name;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float Slow;
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
            monster.SetHP(dmg);
            Ability(monster.gameObject);
        }
    }
    public override void Ability(GameObject Monster)
    {
        Debug.Log("°¨¼Ó");
        Monster.GetComponent<Rigidbody2D>().linearVelocityX /= Slow;
        Monster.GetComponent<Rigidbody2D>().linearVelocityY /= Slow;
    }
}
