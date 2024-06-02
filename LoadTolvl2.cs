using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTolvl2 : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
