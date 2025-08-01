using System.Collections;
using UnityEngine;

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
    private float basicSpeed;
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
        basicSpeed = speed;
    }
    public int gold { get; private set; }
    public int GetNumber()
    {
        return number;
    }

    public void SetHP(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetSpeed(float slow, float time)
    {
        StartCoroutine(SlowDown(slow, time));
    }
    public void SetGold(ulong manyMoney)
    {
        channelSO.ChangeGold(manyMoney,GoldTypeEnum.GET);
    }

    private IEnumerator SlowDown(float slow, float time)
    {
        speed = basicSpeed - slow;
        speed = Mathf.Clamp(speed, 0, basicSpeed);
        yield return new WaitForSeconds(time);
        speed = basicSpeed;
    }
}
