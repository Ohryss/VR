using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Ghost;

    private float spawnEnemyInterval;
    void Start()
    {
        spawnEnemyInterval = Random.Range(1f, 3f);
        StartCoroutine(spawnEnemy(spawnEnemyInterval, Ghost));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-20f, 20f), 2, Random.Range(-20f, 20f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
