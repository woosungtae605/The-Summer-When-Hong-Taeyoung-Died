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

    private void Initialize() //초기 에너미 딕셔너리에 넣어주는 메서드
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

    public void SpawnEnemy(string enemyName) //에너미 스폰하는 매서드. 그냥 이거 가져가서 스폰할 얘 이름만 적으면 됨
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
                Debug.Log("풀 다 떨어짐");
            }
        }
        else
        {
            Debug.Log($"{enemyName}이란 적 이름 없음");
        }
    }

    public void EnemyReturn(string name, GameObject gameObject) // 에너미 죽었을 때, 다시 넣어주는 메서드. 죽은 얘 이름과, 죽은 애의 게임 오브젝트 넣어주면 됨
    {
        if(enemyDic.ContainsKey(name))
        {
            gameObject.SetActive(false);
            enemyDic[name].Push(gameObject);
        }
        else
        {
            Debug.Log("존재하기 않는 에너미 반환");
        }
    }
}
