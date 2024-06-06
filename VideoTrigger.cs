using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTrigger : MonoBehaviour
{
    public GameObject videoCube; // Reference to the GameObject containing the VideoPlayer component
    public string sceneToLoad; // Name of the scene to load after the video finishes

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object is the player
        if (other.CompareTag("Player"))
        {
            // Stop all audio sources in the scene
            StopAllAudio();

            // Activate the video cube
            videoCube.SetActive(true);

            // Get the VideoPlayer component from the cube
            VideoPlayer videoPlayer = videoCube.GetComponentInChildren<VideoPlayer>();

            // Play the video
            videoPlayer.Play();

            // Invoke the method to load the scene after the video finishes
            Invoke("LoadScene", (float)videoPlayer.clip.length);
        }
    }

    private void LoadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(sceneToLoad);
    }

    private void StopAllAudio()
    {
        // Find all audio sources in the scene and stop them
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.Stop();
        }
    }
}
