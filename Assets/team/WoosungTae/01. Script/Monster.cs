using UnityEngine;
using UnityEngine.InputSystem;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterSO;
    [SerializeField] private int number;
    private int hp;
    private float speed;
    private int gold;
    
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
}
