using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject Apple;
    public Vector3 spawnPosition = new Vector3(8.158f, 5.512f, 34.81f);
    public float spawnInterval = 42f;
    private GameObject currentApple;

    private void Start()
    {
        InvokeRepeating("SpawnApple", 0f, spawnInterval);
    }

    private void SpawnApple()
    {
        if (currentApple == null)
        {
            currentApple = Instantiate(Apple, spawnPosition, Quaternion.identity);
        }
    }
}
