using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private int enemyMaxSpawn;
    [SerializeField] private int bulletMaxSpawn;
    [SerializeField] private Transform spawnPosition;
    private Dictionary<int, Stack<GameObject>> enemyDic = new();
    private Stack<GameObject> bulletStack = new();
    private List<GameObject> activeEnemy = new(); // ���� ����ִ� ���ʹ� ��. �̰ɷ� ����ִ� ��� ��, ���� ����� �� ã�°���

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
    }
    private void Start()
    {
        Initialize();
    }
    private void Initialize() //�ʱ� ���ʹ� ��ųʸ��� �־��ִ� �޼���
    {
        foreach(var enemy in enemies)
        {
            Stack<GameObject> stack = new Stack<GameObject>();
            for (int i = 0; i < enemyMaxSpawn; i++ )
            {
                GameObject aboutEnemy = Instantiate(enemy, transform);
                stack.Push(aboutEnemy);
                aboutEnemy.SetActive(false);
            }
            Monster monster = enemy.GetComponent<Monster>();
            Debug.Log(monster.GetNumber());
            enemyDic.Add(monster.GetNumber(), stack);
        }

        foreach(var bullet in bullets)
        {
            for (int i = 0; i < bulletMaxSpawn; i++)
            {
                GameObject aboutBullet = Instantiate(bullet, transform);
                aboutBullet.SetActive(false);
                bulletStack.Push(aboutBullet);
            }
        }
    }

    public void SpawnEnemy(int enemyName) //���ʹ� �����ϴ� �ż���. �׳� �̰� �������� ������ �� ��ȣ�� ������ ��
    {
        if(enemyDic.ContainsKey(enemyName))
        {
            Stack<GameObject> stack = enemyDic[enemyName];
            
            if(stack.Count > 0)
            {
                GameObject enemy = stack.Pop();
                enemy.transform.position = spawnPosition.position;
                enemy.SetActive(true);
                activeEnemy.Add(enemy);
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

    public void SpawnBullet(Transform spawnPosition)
    {
        if(bulletStack.Count > 0)
        {
            GameObject bullet = bulletStack.Pop();
            bullet.transform.position = spawnPosition.position;
            bullet.SetActive(true);
        }
        else
        {
            Debug.Log("�Ѿ��� �� �����");
        }
    }
    public void EnemyReturn(int number, GameObject gameObject) // ���ʹ� �׾��� ��, �ٽ� �־��ִ� �޼���. ���� �� �̸���, ���� ���� ���� ������Ʈ �־��ָ� ��
    {
        if(enemyDic.ContainsKey(number))
        {
            gameObject.SetActive(false);
            enemyDic[number].Push(gameObject);
            activeEnemy.Remove(gameObject);
        }
        else
        {
            Debug.Log("�����ϱ� �ʴ� ���ʹ� ��ȯ");
        }
    }
    public void BulletReturn(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletStack.Push(bullet);
    }

    public List<GameObject> GetActiveEnemy() // �̰ɷ� ����ִ� �ֵ� ��, ���� ����� �� ã��
    {
        return activeEnemy;
    }
}
