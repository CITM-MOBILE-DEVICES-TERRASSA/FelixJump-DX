using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button infiniteTowerButton;

    private void Start()
    {
        if (level1Button != null)
            level1Button.onClick.AddListener(LoadLevel1);

        if (level2Button != null)
            level2Button.onClick.AddListener(LoadLevel2);

        if (level3Button != null)
            level3Button.onClick.AddListener(LoadLevel3);

        if (level4Button != null)
            level4Button.onClick.AddListener(LoadLevel4);

        if (infiniteTowerButton != null)
            infiniteTowerButton.onClick.AddListener(LoadInfiniteTower);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1"); 
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadInfiniteTower()
    {
        SceneManager.LoadScene("TorreInfinita");
    }
}