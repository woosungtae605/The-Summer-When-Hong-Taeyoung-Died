using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private bool canSpawn = false;
    private void Update()
    {
        if(!canSpawn)
        {
            StartCoroutine(EnemySpawn());
        }
    }

    IEnumerator EnemySpawn()
    {
        canSpawn = true;
        SpawnManager.instance.SpawnEnemy(1);
        yield return new WaitForSeconds(1);
        canSpawn = false;
    }

}
