using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons = new Button[5];
    [SerializeField] private bool[] availableLevels = new bool[5];
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject levelsPanel;

    private void Awake()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = availableLevels[i];
        }
    }

    public void SelectLevel(string levelName)
    {
        GameManager.Instance.StartGame();
        GameManager.Instance.ResumeGame();
        ScenesManager.Instance.LoadScene(levelName);
    }

    public void ChangeToLevelSelector()
    {
        gamePanel.SetActive(false);
        levelsPanel.SetActive(true);
    }
}