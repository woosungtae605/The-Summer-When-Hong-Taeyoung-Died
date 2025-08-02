using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpecialBullet))]
public class BulletMove : MonoBehaviour
{
    public GameObject target;
    public int damage;
    public float speed;
    
    private Rigidbody2D rb;
    private SpecialBullet sb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sb = GetComponent<SpecialBullet>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 dir = (target.transform.position - transform.position).normalized;
            rb.linearVelocity = dir * speed;
        }
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Monster>(out Monster monsters))
        {
            sb.Damage(monsters,damage);
            Destroy(gameObject);
        }
        else if (other.TryGetComponent<Monster>(out Monster monster) && sb.type == SpecialBulletType.Piercing)
            monster.SetHP(damage);
    }
}
