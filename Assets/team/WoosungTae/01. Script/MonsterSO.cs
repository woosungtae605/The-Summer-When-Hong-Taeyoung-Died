using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "Scriptable Objects/MonsterSO")]
public class MonsterSO : ScriptableObject
{
    public int monsterNum; // 몬스터 이름
    public int hp; // 몬스터 체력
    public float speed; // 몬스터 스피드
    public int gold; //몬스터 죽을 때, 얻는 골드
}
