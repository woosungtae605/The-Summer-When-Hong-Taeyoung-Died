using System.Collections;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    protected TowerState MyState;
    protected bool isSet = false;
    protected bool ISell = false;
    [SerializeField] private TowerStatSO TowerStatSO;
    public int dmg { set; private get; }
    public float attackSpeed { set; private get; }
    private void Awake()
    {
        Initialize();
        StartCoroutine(Toweraaaaa());
    }
    public void Initialize()
    {

        attackSpeed = TowerStatSO.attackSpeed;
        Range = transform.GetChild(0).gameObject;
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
        Range.SetActive(false);
        MyState = TowerState.Idle;
        /*while (!ISell)
        {
            /*
               if (EnemyInRange())
               {
                   MyState = TowerState.Shoot;
               }
               else
               {
                   MyState = TowerState.Idle;
               }
        }*/
        MyState = TowerState.Sell;
    }
}
