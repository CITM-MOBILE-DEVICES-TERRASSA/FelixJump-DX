using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject cylinderPrefab; 
    public GameObject platformPrefab;

    [Header("Spawn Settings")]
    public int maxObjects = 100; 
    public float spawnIntervalY = 5f;
    public Vector3 spawnPosition = new Vector3(0, 0, 0); 
    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for (int i = 1; i <= maxObjects; i++)
        {
            float yPosition = spawnPosition.y + (i * spawnIntervalY);


            if (i % 50 == 0)
            {
                Instantiate(cylinderPrefab, new Vector3(spawnPosition.x, yPosition, spawnPosition.z), Quaternion.identity);
            }

            if (i % 5 == 0)
            {
                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                Instantiate(platformPrefab, new Vector3(spawnPosition.x, yPosition, spawnPosition.z), randomRotation);
                Quaternion fixedRotation = Quaternion.Euler(0, 0, -90);

            }
        }
    }
}