using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class BackToMenu : MonoBehaviour
{
    public Button switchSceneButton; 
    public Object targetScene; 

    private void Start()
    {
        if (switchSceneButton != null)
        {
            switchSceneButton.onClick.AddListener(SwitchScene);
        }
        else
        {
            Debug.LogError("No se asignó un botón para cambiar de escena en el inspector.");
        }

        if (targetScene == null)
        {
            Debug.LogError("No se asignó una escena objetivo en el inspector.");
        }
    }

    private void SwitchScene()
    {
        if (targetScene != null)
        {
            string sceneName = targetScene.name;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("La referencia a la escena objetivo está vacía. Por favor, asigna una escena válida.");
        }
    }
}
