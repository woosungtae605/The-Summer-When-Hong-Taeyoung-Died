using System.Collections;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    protected TowerState MyState;
    protected bool isSet = false;
    protected bool ISell = false;
    [SerializeField] private TowerStatSO TowerStatSO;
    GameObject Range;
    GameObject AttackTarget;

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
    private void Update()
    {
        AttackTarget = Manager.manager.Spwan.First(transform);
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
        while (!ISell)
        {

            if (AttackTarget != null)
            {
                float distance = Vector3.Distance(AttackTarget.transform.position, transform.position);
                if (distance <= TowerStatSO.Range)
                    MyState = TowerState.Shoot;
                else
                    MyState = TowerState.Idle;
                yield return null;
            }
            else
                MyState = TowerState.Idle;
            yield return null;
        }
        MyState = TowerState.Sell;
    }
}