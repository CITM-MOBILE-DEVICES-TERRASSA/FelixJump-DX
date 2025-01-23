using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
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

            if (i % 5 == 0)
            {
                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0) * platformPrefab.transform.rotation;

                // Instanciar la plataforma como hija del objeto con el script
                Instantiate(platformPrefab, 
                            new Vector3(spawnPosition.x, yPosition, spawnPosition.z), 
                            randomRotation, 
                            this.transform);
            }
        }
    }
}
