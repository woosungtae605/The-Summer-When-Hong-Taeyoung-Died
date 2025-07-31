using System.Collections;
using UnityEngine;

public class TestTower : Tower
{
    private void Awake()
    {
        base.Awake();
       
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
       
    }
   
}
