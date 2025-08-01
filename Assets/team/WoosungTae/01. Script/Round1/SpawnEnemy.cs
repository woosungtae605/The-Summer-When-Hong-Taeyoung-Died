using System.Collections;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemy : MonoBehaviour
{
    private bool canSpawn = false;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Tilemap baseTileMap;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject[] enemies;
    private void Update()
    {
        if(!canSpawn)
        {
          // StartCoroutine(EnemySpawn());
        }
    }
    
    IEnumerator EnemySpawn()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            canSpawn = true;
            GameObject enemy = Instantiate(enemies[i]);
            enemy.transform.position = spawnPosition.transform.position;

            var pathMovement = enemy.GetComponent<PathMovement>();
            if (pathMovement != null)
            {
                pathMovement.SetReferences(baseTileMap, this.target);
            }
            TargetTrace target = enemy.AddComponent<TargetTrace>();
            TargetManager.Instance.targets.Add(target);
            Debug.Log("�۵�");
            yield return new WaitForSeconds(1);
        }
        canSpawn = false;
    }

    public void EnemySpawn_1()
    {
        GameObject enemy = Instantiate(enemies[0]);
        enemy.transform.position = spawnPosition.transform.position;

        var pathMovement = enemy.GetComponent<PathMovement>();
        if (pathMovement != null)
        {
            pathMovement.SetReferences(baseTileMap, this.target);
        }
        TargetTrace target = enemy.AddComponent<TargetTrace>();
        TargetManager.Instance.targets.Add(target);
    }
    public void EnemySpawn_2()
    {
        GameObject enemy = Instantiate(enemies[1]);
        enemy.transform.position = spawnPosition.transform.position;

        var pathMovement = enemy.GetComponent<PathMovement>();
        if (pathMovement != null)
        {
            pathMovement.SetReferences(baseTileMap, this.target);
        }
        TargetTrace target = enemy.AddComponent<TargetTrace>();
        TargetManager.Instance.targets.Add(target);
    }

    public void EnemySpawn_3()
    {
        GameObject enemy = Instantiate(enemies[2]);
        enemy.transform.position = spawnPosition.transform.position;

        var pathMovement = enemy.GetComponent<PathMovement>();
        if (pathMovement != null)
        {
            pathMovement.SetReferences(baseTileMap, this.target);
        }
        TargetTrace target = enemy.AddComponent<TargetTrace>();
        TargetManager.Instance.targets.Add(target);
    }
    public void EnemySpawn_4()
    {
        GameObject enemy = Instantiate(enemies[3]);
        enemy.transform.position = spawnPosition.transform.position;

        var pathMovement = enemy.GetComponent<PathMovement>();
        if (pathMovement != null)
        {
            pathMovement.SetReferences(baseTileMap, this.target);
        }
        TargetTrace target = enemy.AddComponent<TargetTrace>();
        TargetManager.Instance.targets.Add(target);
    }

}


