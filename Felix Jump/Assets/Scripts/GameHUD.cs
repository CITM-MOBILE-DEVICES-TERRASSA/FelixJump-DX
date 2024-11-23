using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        UpdateScoreTexts();
    }

    private void Update()
    {
        UpdateScoreTexts();
    }

    private void UpdateScoreTexts()
    {
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        scoreText.text = Score.Instance.GetScore(currentScene).ToString();
        highScoreText.text = Score.Instance.GetHighScore(currentScene).ToString();
    }

    public void ChangeToMenu()
    {
        ScenesManager.Instance.LoadScene("GameSelector");
        // Score.Instance.SetAddScore(false);
    }
}