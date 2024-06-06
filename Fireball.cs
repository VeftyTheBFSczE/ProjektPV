using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public GameObject videoCube; // Reference to the cube with the VideoPlayer component
    private VideoPlayer videoPlayer; // Reference to the VideoPlayer component of the cube
    public string nextSceneName; // Name of the next scene to load
    public float fireballLifetime = 1f; // Lifetime of the fireball in seconds

    private void OnTriggerEnter(Collider other)
    {
        // Check if the fireball collides with the player
        if (other.CompareTag("Player"))
        {
            // Call the method to handle player defeat
            HandlePlayerDefeat();
        }
    }

    private void HandlePlayerDefeat()
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

        // Start the coroutine to destroy the fireball after a delay
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(fireballLifetime);

        // Destroy the fireball
        Destroy(gameObject);
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Unsubscribe from the event to avoid multiple calls
        vp.loopPointReached -= OnVideoEnd;

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
