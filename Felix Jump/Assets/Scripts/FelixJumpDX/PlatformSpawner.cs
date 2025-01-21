using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 10; 
    public float verticalSpacing = 5f; 

    private void Start()
    {
        SpawnPlatforms();
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Vector3 spawnPosition = new Vector3(0, i * verticalSpacing, 0);

            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

            Instantiate(platformPrefab, spawnPosition, randomRotation);
        }
    }
}