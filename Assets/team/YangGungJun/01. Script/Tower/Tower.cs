using System.Collections;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    protected TowerState MyState;
    protected bool isSet = false;
    protected bool ISell = false;
    [SerializeField] private TowerStatSO TowerStatSO;
    public int dmg { set; get; }
    public float attackSpeed { set; get; }
    public int updateCost { set;  get; }
    public int sellCost { set; get; }
    public float range { set; get; }

    private void Awake()
    {
        Initialize();
        StartCoroutine(Toweraaaaa());
    }
    public void Initialize()
    {
        dmg = TowerStatSO.dmg;
        attackSpeed = TowerStatSO.attackSpeed;
        range = TowerStatSO.Range;
    }
    public void SetDmg(int value)
    {
        dmg += value;
    }
    public void AttackSpeed(float value)
    {
        attackSpeed += value;
    }
    public void SetRange(float value)
    {
        range += value;
    }
    public void SetUpdateCost(int value)
    {
        updateCost += value;
    }
    public void SetSellcost(int value)
    {
        sellCost += value;
    }
    public abstract void Shoot();

    IEnumerator Toweraaaaa()//鸥况 积局林扁
    {
        MyState = TowerState.Set;
        yield return new WaitUntil(() => isSet);
        MyState = TowerState.Idle;
        while (!ISell)
        {
            /*
               if (EnemyInRange())
               {
                   MyState = TowerState.Shoot;
               }
               else
               {
                   MyState = TowerState.Idle;
               }*/
        }
        MyState = TowerState.Sell;
    }
}
