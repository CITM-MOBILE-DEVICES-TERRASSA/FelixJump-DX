using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject FireballPrefab;
    public float FireballSpawnInterval;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {

        yield return new WaitForSeconds(Random.Range(0, FireballSpawnInterval));
        
        while (true)
            yield return SpawnFireball();
    }

    IEnumerator SpawnFireball()
    {
        var f = Instantiate(FireballPrefab, transform.position, transform.rotation);
        f.transform.parent = transform;
        
        yield return new WaitForSeconds(FireballSpawnInterval);
    }
    
}
