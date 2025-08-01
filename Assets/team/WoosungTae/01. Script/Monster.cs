using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterSO;

   
    private int WayPointCount;
    private int currentCount;
    [SerializeField] private int number;
    
    [SerializeField] GameObject[] point;
    public int hp { get; private set; }
    private void Start()
    {
        
    }
    private void Initialize()
    {
        number = monsterSO.monsterNum;
        hp = monsterSO.hp;
        gold = monsterSO.gold;
    }
<<<<<<< HEAD
    public int gold { get; private set; }
=======

    private void Update()
    {
        if(hp <= 0)
        {
            SpawnManager.instance.EnemyReturn(number,gameObject);
        }
        Debug.Log(number);
    }
>>>>>>> main
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
