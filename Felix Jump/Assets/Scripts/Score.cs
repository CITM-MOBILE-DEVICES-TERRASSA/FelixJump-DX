using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score instance;
    public static Score Instance => instance;

    [SerializeField] private int autumnScore;
    [SerializeField] private int halloweenScore;
    [SerializeField] private int springScore;
    [SerializeField] private int winterScore;
    [SerializeField] private int summerScore;

    [SerializeField] private int maxAutumnScore;
    [SerializeField] private int maxHalloweenScore;
    [SerializeField] private int maxSpringScore;
    [SerializeField] private int maxWinterScore;
    [SerializeField] private int maxSummerScore;

    [SerializeField] private int maxTotalScore;

    [SerializeField] private float scoreTimer = 0f;
    [SerializeField] private bool addScore = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerPrefs.SetInt("MaxAutumnScore", 0);

        maxAutumnScore = PlayerPrefs.GetInt("MaxAutumnScore", 0);
        maxHalloweenScore = PlayerPrefs.GetInt("MaxHalloweenScore", 0);
        maxSpringScore = PlayerPrefs.GetInt("MaxSpringScore", 0);
        maxWinterScore = PlayerPrefs.GetInt("MaxWinterScore", 0);
        maxSummerScore = PlayerPrefs.GetInt("MaxSummerScore", 0);
        maxTotalScore = PlayerPrefs.GetInt("MaxTotalScore", 0);
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && addScore)
        {
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= 1f)
            {
                AddScore(1);
                scoreTimer = 0f;
            }
        }
        else
            scoreTimer = 0f;
    }

    public void AddScore(int value)
    {
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        bool maxScoreUpdated = false;

        switch (currentScene)
        {
            case "AutumnLevel":
                autumnScore += value;
                if (autumnScore > maxAutumnScore)
                {
                    maxAutumnScore = autumnScore;
                    PlayerPrefs.SetInt("MaxAutumnScore", maxAutumnScore);
                    maxScoreUpdated = true;
                }
                break;
            case "HalloweenLevel":
                halloweenScore += value;
                if (halloweenScore > maxHalloweenScore)
                {
                    maxHalloweenScore = halloweenScore;
                    PlayerPrefs.SetInt("MaxHalloweenScore", maxHalloweenScore);
                    maxScoreUpdated = true;
                }
                break;
            case "SpringLevel":
                springScore += value;
                if (springScore > maxSpringScore)
                {
                    maxSpringScore = springScore;
                    PlayerPrefs.SetInt("MaxSpringScore", maxSpringScore);
                    maxScoreUpdated = true;
                }
                break;
            case "WinterLevel":
                winterScore += value;
                if (winterScore > maxWinterScore)
                {
                    maxWinterScore = winterScore;
                    PlayerPrefs.SetInt("MaxWinterScore", maxWinterScore);
                    maxScoreUpdated = true;
                }
                break;
            case "SummerLevel":
                summerScore += value;
                if (summerScore > maxSummerScore)
                {
                    maxSummerScore = summerScore;
                    PlayerPrefs.SetInt("MaxSummerScore", maxSummerScore);
                    maxScoreUpdated = true;
                }
                break;
        }

        if (maxScoreUpdated)
        {
            UpdateMaxTotalScore();
        }

        PlayerPrefs.Save();
    }

    private void UpdateMaxTotalScore()
    {
        maxTotalScore = maxAutumnScore + maxHalloweenScore + maxSpringScore + maxWinterScore + maxSummerScore;
        PlayerPrefs.SetInt("MaxTotalScore", maxTotalScore);
    }

    public int GetScore(string levelName)
    {
        switch (levelName)
        {
            case "AutumnLevel":
                return autumnScore;
            case "HalloweenLevel":
                return halloweenScore;
            case "SpringLevel":
                return springScore;
            case "WinterLevel":
                return winterScore;
            case "SummerLevel":
                return summerScore;
            default:
                return 0;
        }
    }
    
    public int GetHighScore(string levelName)
    {
        switch (levelName)
        {
            case "AutumnLevel":
                return maxAutumnScore;
            case "HalloweenLevel":
                return maxHalloweenScore;
            case "SpringLevel":
                return maxSpringScore;
            case "WinterLevel":
                return maxWinterScore;
            case "SummerLevel":
                return maxSummerScore;
            default:
                return 0;
        }
    }
}