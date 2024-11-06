using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score instance;
    public static Score Instance => instance;

    private int score;
    private int highScore;
    private float scoreTimer = 0f;
    private bool addScore = true;

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

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameScene" && addScore)
        {
            //Debug.Log("Score: " + score);
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
        score += value;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public int GetScore() => score;
    public int GetHighScore() => highScore;
    public void ResetScore() => score = 0;
    public void SetAddScore(bool value) => addScore = value;
}
