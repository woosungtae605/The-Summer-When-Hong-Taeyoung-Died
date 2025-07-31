using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [Header("Settings")] 
    public TowerOwnStatSO stat;
    public GameObject target;
    
    
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

            if (canShoot && math.distance(target.transform.position, transform.position) <= stat.range)
            {
                StartCoroutine(ShootDelay());
                BulletMove bullet =
                    Instantiate(Resources.Load("Bullet") as GameObject, transform.position, Quaternion.identity)
                        .GetComponent<BulletMove>();
                bullet.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                bullet.gameObject.GetComponent<SpriteRenderer>().color = stat.bulletColor;
                bullet.target = target;
                bullet.speed = stat.bulletSpeed;
                bullet.damage = stat.dmg;
            }
        }
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(stat.rate);
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stat.range);
    }
}
