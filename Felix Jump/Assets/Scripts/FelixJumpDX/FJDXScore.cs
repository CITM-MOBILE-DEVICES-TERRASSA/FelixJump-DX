using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FJDXScore : MonoBehaviour
{
    public List<GameObject> platformsReached = new List<GameObject>();
    public float timeElapsed = 0f;
    public static bool GoalReached = false;

    private void Start()
    {
        GoalReached = false;
    }

    void Update()
    {
        if (!GoalReached)
            timeElapsed += Time.deltaTime;
    }

    public void OnLandOnPlatform(GameObject platform)
    {
        if (platform.CompareTag("Plataforma") && !platformsReached.Contains(platform))
        {
            platformsReached.Add(platform);
        }
        else if (platform.CompareTag("Meta"))
        {
            Debug.Log("Goal Reached!");
            GoalReached = true;
        }
    }
    
    
}