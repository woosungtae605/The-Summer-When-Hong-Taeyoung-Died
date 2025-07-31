using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterSO;
    private string name;
    private int hp;
    private float speed;
    private int gold;
    private void Awake()
    {
        name = monsterSO.name;
        hp = monsterSO.hp;
        speed = monsterSO.speed;
        gold = monsterSO.gold;
    }
}
