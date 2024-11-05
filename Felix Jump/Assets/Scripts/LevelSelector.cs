using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons = new Button[5];
    [SerializeField] private bool[] availableLevels = new bool[5];

    private void Awake()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = availableLevels[i];
        }
    }

    public void SelectLevel(string levelName)
    {
        ScenesManager.Instance.LoadScene(levelName);
    }
}