using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour
{
    public GameObject target;
    public int damage;
    public float speed;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (other.tag == target.tag)
            Destroy(gameObject);
    }
}
