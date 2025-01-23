using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FJDXScoreData
{
    public int[] highScore = new int[5];
    
}

public class FJDXScore : MonoBehaviour
{
    public List<GameObject> platformsReached = new List<GameObject>();
    public float timeElapsed = 0f;
    public static bool GoalReached = false;
    public int level = 0;
    public FJDXScoreData data;

    private void Start()
    {
        string json = "";
        PlayerPrefs.GetString("FelixJumpDXScore", json);
        data = JsonUtility.FromJson<FJDXScoreData>(json);
        
        
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
            var victoryScreen = FindObjectOfType<OnVictoryScript>();
            if (victoryScreen)
            {
                int score = CalculateScore();
                victoryScreen.scoreText.text += score;
                
                // Si valor de nivel es valido y la puntuacion es mas alta, muestra que has logrado un record y guarda la nueva puntuacion
                if (level >= 0 && level < data.highScore.Length)
                    if (score > data.highScore[level])
                    {
                        data.highScore[level] = score;
                        victoryScreen.highScorePopup.gameObject.SetActive(true);
                    }
                
                victoryScreen.ShowVictoryScreen();
            }
        }
    }

    private int CalculateScore()
    {
        int score = platformsReached.Count * 10 + Mathf.Max(300 - (int)timeElapsed, 0) * 5;
        return score;
    }

    private void SaveScore()
    {
        if (level < 0 || level >= data.highScore.Length)
        {
            Debug.Log("Level not assigned on the score script");
            return;
        }
        
        string json = JsonUtility.ToJson(data, true);

        PlayerPrefs.SetString("FelixJumpDXScore", json);
        PlayerPrefs.Save();

    }
    
}
