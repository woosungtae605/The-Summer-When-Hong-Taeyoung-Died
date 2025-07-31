using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterSO;

    private MonsterMovement movement;
    private int WayPointCount;

    [SerializeField] private int number;
    
    [SerializeField] GameObject[] point;
    public int hp { get; private set; }
    private void Start()
    {
        movement = GetComponent<MonsterMovement>();
    }
    private void Initialize()
    {

    }
    public int gold { get; private set; }
    private int currentCount;
    private void OnEnable()
    {
       
        number = monsterSO.monsterNum;
        hp = monsterSO.hp;
        
        gold = monsterSO.gold;
        Debug.Log("½ÇÇàµÊ");
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
        
    }
    public void SetGold(int manyMoney)
    {
        gold += manyMoney;
    }
}
