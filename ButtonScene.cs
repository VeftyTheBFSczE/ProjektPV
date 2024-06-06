using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    public void LoadSceneOnClick()
    {
        // Load the scene specified by sceneName
        SceneManager.LoadScene(sceneName);
    }

 public void QuitOnClick()
    {
        // Quit the application
        Application.Quit();
    }

}
