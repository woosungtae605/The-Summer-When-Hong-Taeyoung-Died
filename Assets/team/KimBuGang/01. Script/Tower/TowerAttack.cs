using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [Header("Settings")]
    public GameObject target;
    public int damage;
    public float rate;
    public float range;
    public float bulletSpeed;
    
    [Header("Cost")]
    public int upgradeCost;
    public int sellCost;
    
    private Rigidbody2D rb;

    private bool canShoot = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 newPos = target.transform.position - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (canShoot && math.distance(target.transform.position, transform.position) <= range)
            {
                StartCoroutine(ShootDelay());
                BulletMove bullet =
                    Instantiate(Resources.Load("Bullet") as GameObject, transform.position, Quaternion.identity)
                        .GetComponent<BulletMove>();
                bullet.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                bullet.target = target;
                bullet.speed = bulletSpeed;
                bullet.damage = damage;
            }
        }
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(rate);
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
