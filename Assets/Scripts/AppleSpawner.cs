using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject Apple;
    public GameObject Banana;
    public Vector3 spawnPositionApple = new Vector3(8.158f, 5.512f, 34.81f);
    public Vector3 spawnPositionBanana = new Vector3(8.158f, 5.512f, 34.81f);
    public float spawnIntervalApple = 42f;
    public float spawnIntervalBanana = 13f;
    private GameObject currentApple;
    private GameObject currentBanana;

    private void Start()
    {
        InvokeRepeating("SpawnApple", 0f, spawnIntervalApple);
        InvokeRepeating("SpawnBanana", 0f, spawnIntervalBanana);
    }

    private void SpawnApple()
    {
        if (currentApple == null)
        {
            currentApple = Instantiate(Apple, spawnPositionApple, Quaternion.identity);
        }
    }
        private void SpawnBanana()
    {
        if (currentApple == null)
        {
            currentApple = Instantiate(Banana, spawnPositionBanana, Quaternion.identity);
        }
    }
}
