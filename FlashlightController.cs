using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FlashlightController : MonoBehaviour
{
    public AudioClip turnOnSound;
    public AudioClip turnOffSound;

    private Light flashlight;
    private AudioSource audioSource;

    private void Start()
    {
        flashlight = GetComponent<Light>();
        if (flashlight == null)
        {
            Debug.LogWarning("Light component is not attached. Attach a Light component manually.");
        }
        else
        {
            flashlight.enabled = false;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight != null)
            {
                flashlight.enabled = !flashlight.enabled;
                if (flashlight.enabled)
                {
                    PlayAudioEffect(turnOnSound);
                }
                else
                {
                    PlayAudioEffect(turnOffSound);
                }
            }
            else
            {
                Debug.LogWarning("Cannot control flashlight as Light component is not attached.");
            }
        }
    }

    private void PlayAudioEffect(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
