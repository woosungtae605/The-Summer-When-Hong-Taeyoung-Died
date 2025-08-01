using System.Collections;
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
            StartCoroutine(EnemySpawn());
        }
    }

    IEnumerator EnemySpawn()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            canSpawn = true;
            GameObject enemy = Instantiate(enemies[i]);
            enemy.transform.position = spawnPosition.transform.position;
            var pathMovement = enemy.GetComponent<PathMovement>();
            if (pathMovement != null)
            {
                pathMovement.SetReferences(baseTileMap, this.target);
            }
            yield return new WaitForSeconds(1);
        }
            
        //TargetTrace target = enemy.AddComponent<TargetTrace>();
       // TargetManager.Instance.targets.Add(target);

        canSpawn = false;
    }

}
