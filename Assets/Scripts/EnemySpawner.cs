using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Ghost;
    public float x1 = 0f;
    public float x2 = 0f;
    public float z1 = 0f;
    public float z2 = 0f;
    public float SpawnSpd1 = 0.5f;
    public float SpawnSpd2 = 1f;

    private float spawnEnemyInterval;
    void Start()
    {
        spawnEnemyInterval = Random.Range(SpawnSpd1, SpawnSpd2);
        StartCoroutine(spawnEnemy(spawnEnemyInterval, Ghost));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(x1, x2), 3.5f, Random.Range(z1, z2)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
