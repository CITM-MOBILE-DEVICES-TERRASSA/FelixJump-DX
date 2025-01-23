using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnVictoryScript : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreen;
    public TMP_Text scoreText;
    
    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }
}
