using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Stage1Spawn : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;

    private void Awake()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();    
    }

    private void Start()
    {
        StartCoroutine(Stage());
    }

    IEnumerator Stage()
    {
        for(int i = 0; i < 8; i++)
        {
            spawnEnemy.EnemySpawn_1();
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(10);
        for (int i = 0; i < 15; i++)
        {
            spawnEnemy.EnemySpawn_1();
            yield return new WaitForSeconds(1);
        }
        spawnEnemy.EnemySpawn_2();
        yield return new WaitForSeconds(10);
        for (int i = 0; i < 7; i++)
        {
            spawnEnemy.EnemySpawn_1();
            yield return new WaitForSeconds(1.5f);
            spawnEnemy.EnemySpawn_1();
            spawnEnemy.EnemySpawn_2();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
