using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private int enemyMaxSpawn;
    [SerializeField] private int bulletMaxSpawn;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Tilemap baseTileMap;
    [SerializeField] private Transform target;
    private Dictionary<int, Stack<GameObject>> enemyDic = new();
    private Stack<GameObject> bulletStack = new();
    private List<GameObject> activeEnemy = new(); // 현재 살아있는 에너미 수. 이걸로 살아있는 얘들 중, 가장 가까운 적 찾는거임

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
    private void Initialize() //초기 에너미 딕셔너리에 넣어주는 메서드
    {
        foreach(var enemy in enemies)
        {
            Stack<GameObject> stack = new Stack<GameObject>();
            for (int i = 0; i < enemyMaxSpawn; i++ )
            {
                GameObject instance = Instantiate(enemy, transform);
                var pathMovement = instance.GetComponent<PathMovement>();
                if (pathMovement != null)
                    pathMovement.SetReferences(baseTileMap, target);
                stack.Push(instance);
                instance.SetActive(false);
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

    public void SpawnEnemy(int enemyName) //에너미 스폰하는 매서드. 그냥 이거 가져가서 스폰할 얘 번호만 적으면 됨
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
                Debug.Log("에너미 스폰");
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
            Debug.Log("총알이 다 떨어졋음");
        }
    }
    public void EnemyReturn(int number, GameObject gameObject) // 에너미 죽었을 때, 다시 넣어주는 메서드. 죽은 얘 이름과, 죽은 애의 게임 오브젝트 넣어주면 됨
    {
        if(enemyDic.ContainsKey(number))
        {
            gameObject.SetActive(false);
            enemyDic[number].Push(gameObject);
            activeEnemy.Remove(gameObject);
        }
        else
        {
            Debug.Log("존재하기 않는 에너미 반환");
        }
    }
    public void BulletReturn(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletStack.Push(bullet);
    }

    public List<GameObject> GetActiveEnemy() // 이걸로 살아있는 애들 중, 가장 가까운 적 찾기
    {
        return activeEnemy;
    }

    public GameObject First(Transform towerPosition) //에너미 우선순위 정하기
    {
        float saveDistance = 100;
        GameObject a = null;
        foreach (var choidan_Distance in activeEnemy)
        {
            float distance = (towerPosition.position - choidan_Distance.transform.position).sqrMagnitude;
            if (saveDistance > distance)
            {
                saveDistance = distance;
                a = choidan_Distance;   
            }
        }
        return a;
        
    }
}
