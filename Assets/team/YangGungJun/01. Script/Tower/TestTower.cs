using System.Collections;
using UnityEngine;

public class TestTower : Tower
{
    [SerializeField] GameObject Bullet;
    Bullet bulletAbility;
    private void Awake()
    {
        base.Awake();
        bulletAbility = Bullet.GetComponent<Bullet>();
    }
    private void Update()
    {
        if (MyState ==TowerState.Shoot)
        {
            Shoot();
        }
    }
    public override void Shoot()
    {
        bulletAbility.Ability();
    }
   
}
