using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Singleton
    private static SceneLoader _instance;
    public static SceneLoader Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    #endregion

    public void LoadMainLobby()
    {
        SceneManager.LoadScene(sceneName: "GameSelector");
    }
    public void LoadMeta()
    {
        SceneManager.LoadScene(sceneName: "VacacionesMetaScreen");
    }
    public void LoadGameplay()
    {
        SceneManager.LoadScene(sceneName: "VacacionesLevel 1");
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName: sceneName);
    }
}
