using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalItems = 8; // Total number of collectible items required to win
    private int collectedItems = 0; // Number of items collected by the player
    public GameObject videoCube; // Reference to the cube with the VideoPlayer component
    private VideoPlayer videoPlayer; // Reference to the VideoPlayer component of the cube
    public string nextSceneName; 

    public void CollectItem()
    {
        // Increment the collected item count
        collectedItems++;

        // Check if the player has collected all items
        if (collectedItems == totalItems)
        {
            WinGame();
        }
    }

    public void ReachFinalTrigger()
    {
        // Check if the player has collected all items
        if (collectedItems == totalItems)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        Debug.Log("You win!");
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void LoseGame()
    {
        
    
        // Stop all audio sources
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.Stop();
        }

        // Activate the video cube (if not already active)
        if (videoCube != null && !videoCube.activeSelf)
        {
            videoCube.SetActive(true);

            // Get the VideoPlayer component of the video cube
            videoPlayer = videoCube.GetComponent<VideoPlayer>();

            // Check if the VideoPlayer component is found
            if (videoPlayer != null)
            {
                // Subscribe to the videoPlayer's event for when the video ends
                videoPlayer.loopPointReached += OnVideoEnd;
            }
            else
            {
                Debug.LogError("VideoPlayer component not found on the videoCube GameObject!");
            }
        }

        SceneManager.LoadScene("GameOver");
    }
        private void OnVideoEnd(VideoPlayer vp)
    {
        // Unsubscribe from the event to avoid multiple calls
        vp.loopPointReached -= OnVideoEnd;

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
