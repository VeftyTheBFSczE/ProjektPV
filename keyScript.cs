using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public GameObject currentTrigger; // Current trigger to be deactivated
    public GameObject nextTrigger; // Next trigger to be activated

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the key
        if (other.gameObject.CompareTag("Player"))
        {
            // Enable a prompt or UI to inform the player they can pick up the key
            Debug.Log("Press 'E' to pick up the key!");

            // Assign the current trigger and next trigger
            currentTrigger = GameObject.FindGameObjectWithTag("CurrentTrigger");
            nextTrigger = GameObject.FindGameObjectWithTag("NextTrigger");

            currentTrigger.SetActive(false);

            // Activate the next trigger
            nextTrigger.SetActive(true);

            // Assign the key prefab
           Destroy(gameObject);

        }
    }
}
