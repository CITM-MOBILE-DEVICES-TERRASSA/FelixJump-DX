using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public void PauseGame()
    {        
        pausePanel.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}