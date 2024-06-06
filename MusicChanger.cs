using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioClip newMusic; // The new music clip to play
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger collider
        if (other.CompareTag("Player"))
        {
            // Change the background music to the new music clip
            ChangeMusic();
        }
    }

    private void ChangeMusic()
    {
        // Check if the AudioSource component is assigned and the new music clip is not null
        if (audioSource != null && newMusic != null)
        {
            // Change the audio clip to the new music
            audioSource.clip = newMusic;

            // Play the new music
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or new music clip is not assigned");
        }
    }
}
