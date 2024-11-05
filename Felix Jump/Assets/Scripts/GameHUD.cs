using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        scoreText.text = "Score: " + Score.Instance.GetScore().ToString();
        highScoreText.text = "High Score: " + Score.Instance.GetHighScore().ToString();
    }

    private void Update()
    {
        scoreText.text = Score.Instance.GetScore().ToString();
        highScoreText.text = Score.Instance.GetHighScore().ToString();
    }

    public void ChangeToMenu()
    {
        ScenesManager.Instance.LoadScene("GameSelector");
        Score.Instance.SetAddScore(false);
    }
}