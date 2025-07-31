using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int MaxSpawn;
    [SerializeField] private Transform spawnPosition;
    private Dictionary<string, Stack<GameObject>> enemyDic = new();
    private int[] SpawnNumber;
    private void Awake()
    {
        SpawnNumber = new int[MaxSpawn];
        Initialize();
    }

    private void Initialize()
    {
        foreach(var enemy in enemies)
        {
            Monster monster = enemy.GetComponent<Monster>();
            Stack<GameObject> stack = new Stack<GameObject>();
            for (int i = 0; i < SpawnNumber.Length; i++ )
            {
                GameObject aboutEnemy = Instantiate(enemy, transform);
                aboutEnemy.transform.position = spawnPosition.position;
                aboutEnemy.SetActive(false);
                stack.Push(aboutEnemy);
            }
            enemyDic.Add(monster.name, stack);
        }
    }


}
