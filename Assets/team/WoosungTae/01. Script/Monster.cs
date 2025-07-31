using UnityEngine;
using UnityEngine.InputSystem;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterSO;
    [SerializeField] private int number;
    public int hp { get; private set; }
    public float speed { get; private set; }
    public int gold { get; private set; }
    
    private void OnEnable()
    {
       
        number = monsterSO.monsterNum;
        hp = monsterSO.hp;
        speed = monsterSO.speed;
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
        speed -= slow;
    }
    public void SetGold(int manyMoney)
    {
        gold += manyMoney;
    }
}
