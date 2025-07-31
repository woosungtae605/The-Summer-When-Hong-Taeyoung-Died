using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldakBullet : Bullet
{
    [SerializeField] string name;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float Slow;
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
            Ability(monster.gameObject);
        }
    }
    public override void Ability(GameObject monster)
    {
       
    }
    IEnumerator dmg123()
    {
        yield return new WaitForSeconds(3);
    }
}
