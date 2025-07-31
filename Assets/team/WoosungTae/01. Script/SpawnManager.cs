using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int maxSpawn;
    [SerializeField] private Transform spawnPosition;
    private Dictionary<string, Stack<GameObject>> enemyDic = new();

    public static SpawnManager instance { get; private set; }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Initialize();
    }

    private void Initialize() //�ʱ� ���ʹ� ��ųʸ��� �־��ִ� �޼���
    {
        foreach(var enemy in enemies)
        {
            Monster monster = enemy.GetComponent<Monster>();
            Stack<GameObject> stack = new Stack<GameObject>();
            for (int i = 0; i < maxSpawn; i++ )
            {
                GameObject aboutEnemy = Instantiate(enemy, transform);
                aboutEnemy.SetActive(false);
                stack.Push(aboutEnemy);
            }
            enemyDic.Add(monster.name, stack);
        }
    }

    public void SpawnEnemy(string enemyName) //���ʹ� �����ϴ� �ż���. �׳� �̰� �������� ������ �� �̸��� ������ ��
    {
        if(enemyDic.ContainsKey(enemyName))
        {
            Stack<GameObject> stack = enemyDic[enemyName];
            
            if(stack.Count > 0)
            {
                GameObject enemy = stack.Pop();
                enemy.transform.position = spawnPosition.position;
                enemy.SetActive(true);
            }
            else
            {
                Debug.Log("Ǯ �� ������");
            }
        }
        else
        {
            Debug.Log($"{enemyName}�̶� �� �̸� ����");
        }
    }

    public void EnemyReturn(string name, GameObject gameObject) // ���ʹ� �׾��� ��, �ٽ� �־��ִ� �޼���. ���� �� �̸���, ���� ���� ���� ������Ʈ �־��ָ� ��
    {
        if(enemyDic.ContainsKey(name))
        {
            gameObject.SetActive(false);
            enemyDic[name].Push(gameObject);
        }
        else
        {
            Debug.Log("�����ϱ� �ʴ� ���ʹ� ��ȯ");
        }
    }
}
