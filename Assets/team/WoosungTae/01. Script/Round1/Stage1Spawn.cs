using System.Collections;
using TMPro;
using UnityEngine;

public class Stage1Spawn : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;
    [SerializeField] private TextMeshProUGUI waveText;
    private int waveNum = 0;
    private void Awake()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();    
    }

    private void Start()
    {
        StartCoroutine(Stage());
        WaveNumPlus();
    }

    private void WaveNumPlus()
    {
        waveNum++;
        waveText.text = $"wave : {waveNum} / 8";
    }

    IEnumerator Stage()
    {
        yield return new WaitForSeconds(10);
        for(int i = 0; i < 8; i++) //1스테이지
        {
            spawnEnemy.EnemySpawn_1();
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(10);
        WaveNumPlus();
        for (int i = 0; i < 15; i++) // 2스테이지
        {
            spawnEnemy.EnemySpawn_1();
            yield return new WaitForSeconds(0.6f);
        }
        spawnEnemy.EnemySpawn_2();
        yield return new WaitForSeconds(8);
        WaveNumPlus();
        for (int i = 0; i < 8; i++) // 3스테이지
        {
            spawnEnemy.EnemySpawn_1();
            yield return new WaitForSeconds(0.5f);
            spawnEnemy.EnemySpawn_1();
            yield return new WaitForSeconds(0.1f);
            spawnEnemy.EnemySpawn_2();
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(8);
        WaveNumPlus();
        for (int i = 0; i < 9; i++) // 4스테이지
        {
            spawnEnemy.EnemySpawn_2();
            yield return new WaitForSeconds(0.7f);
        }
        spawnEnemy.EnemySpawn_3();
        yield return new WaitForSeconds(1);
        spawnEnemy.EnemySpawn_3();
        yield return new WaitForSeconds(8);
        WaveNumPlus();
        for (int i = 0; i < 10; i++) // 5스테이지
        {
            spawnEnemy.EnemySpawn_3();
            if(i > 4)
            {
                spawnEnemy.EnemySpawn_1();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);
            if(i > 6)
            {
                spawnEnemy.EnemySpawn_2();
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return new WaitForSeconds(8);
        WaveNumPlus();
        for (int i = 0; i < 12; i++) // 6스테이지
        {
            spawnEnemy.EnemySpawn_3();
            yield return new WaitForSeconds(0.5f);
            if (i > 6)
            {
                spawnEnemy.EnemySpawn_3();
                yield return new WaitForSeconds(0.1f);
                spawnEnemy.EnemySpawn_2();
            }
            if(i > 9)
            {
                yield return new WaitForSeconds(0.2f);
                spawnEnemy.EnemySpawn_2();
                yield return new WaitForSeconds(0.1f);
                spawnEnemy.EnemySpawn_2();
            }
        }
        yield return new WaitForSeconds(8);
        WaveNumPlus();
        for (int i = 0; i < 15; i++) // 7스테이지
        {
            spawnEnemy.EnemySpawn_3();
            yield return new WaitForSeconds(0.4f);
            if (i > 3)
            {
                spawnEnemy.EnemySpawn_2();
                yield return new WaitForSeconds(0.1f);
                spawnEnemy.EnemySpawn_1(); 
            }
            if (i > 11)
            {
                yield return new WaitForSeconds(0.2f);
                spawnEnemy.EnemySpawn_2();
                yield return new WaitForSeconds(0.1f);
                spawnEnemy.EnemySpawn_4();
            }
        }

        for (int i = 0; i < 15; i++) // 8스테이지
        {
            spawnEnemy.EnemySpawn_4();
            yield return new WaitForSeconds(0.4f);
            if (i > 3)
            {
                spawnEnemy.EnemySpawn_2();
                yield return new WaitForSeconds(0.1f);
                spawnEnemy.EnemySpawn_1();
            }
            if (i > 9)
            {
                yield return new WaitForSeconds(0.2f);
                spawnEnemy.EnemySpawn_3();
                yield return new WaitForSeconds(0.1f);
                spawnEnemy.EnemySpawn_2();
            }
        }


    }
}
