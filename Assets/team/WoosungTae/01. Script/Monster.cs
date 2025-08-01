using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterSO;
    public GoldChannelSO channelSO;
   
    private int WayPointCount;
    private int currentCount;
    [SerializeField] private int number;
    
    [SerializeField] GameObject[] point;
    public int hp { get; private set; }
    public float speed { get; private set; }
    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        number = monsterSO.monsterNum;
        speed = monsterSO.speed;
        hp = monsterSO.hp;
        gold = monsterSO.gold;
    }
    public int gold { get; private set; }
    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public int GetNumber()
    {
        return number;
    }

    public void SetHP(int damage)
    {
        hp -= damage;
    }
    public void SetSpeed(float slow)
    {
        speed -= slow;
    }
    public void SetGold(ulong manyMoney)
    {
        channelSO.ChangeGold(manyMoney,GoldTypeEnum.GET);
    }
}
