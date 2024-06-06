using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoRedirect : MonoBehaviour
{
    public string videoURL = "https://www.youtube.com/watch?v=I3gMvk9JPQc"; // URL of the video
    public string nextSceneName; // Name of the next scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider belongs to the player
        {
            OpenVideo(); // Open the video URL
        }
    }

    public void OpenVideo()
    {
        Application.OpenURL(videoURL);
        LoadNextScene(); // Load the next scene after opening the video
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not specified!");
        }
    }
}
