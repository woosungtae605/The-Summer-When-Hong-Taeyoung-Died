using System.Collections;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    protected TowerState MyState;
    protected bool isSet = false;
    protected bool ISell = false;
    [SerializeField] private TowerStatSO TowerStatSO;
    GameObject Range;

    public float attackSpeed { set; private get; }
    protected void Awake()
    {
        Initialize();
        StartCoroutine(Toweraaaaa());
    }
    public void Initialize()
    {

        attackSpeed = TowerStatSO.attackSpeed;
        Range = transform.GetChild(0).gameObject;
    }
    public void AttackSpeed(float value)
    {
        attackSpeed = value;
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
