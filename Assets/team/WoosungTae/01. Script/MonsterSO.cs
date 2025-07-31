using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "Scriptable Objects/MonsterSO")]
public class MonsterSO : ScriptableObject
{
    public int monsterNum; // ���� �̸�
    public int hp; // ���� ü��
    public float speed; // ���� ���ǵ�
    public int gold; //���� ���� ��, ��� ���
}
