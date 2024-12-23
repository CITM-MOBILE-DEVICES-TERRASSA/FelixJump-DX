using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Reads score from each game's save file and shows it on the lobby screen
public class LobbyScoreDX : MonoBehaviour
{

    // Score display for each game in order
    public TMP_Text[] scoreTexts;
    // Path to each save file within the application directory
    public string[] saveFilePaths;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //WIP
    void DisplayFromJSON(string path, int index)
    {
        string json = System.IO.File.ReadAllText(path);
        scoreTexts[index].text = json;
    }

    void DisplayFromPPrefs(string[] keys, int index)
    {
        int score = 0;
        foreach (string key in keys)
        {
            score += PlayerPrefs.GetInt(key);
        }
        scoreTexts[index].text = score.ToString();
    }
    
}
