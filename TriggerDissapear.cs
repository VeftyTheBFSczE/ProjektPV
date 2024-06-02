using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E; // Key to pick up the key
    public GameObject currentTrigger; // Current trigger to be deactivated
    public GameObject nextTrigger; // Next trigger to be activated
    public GameObject keyPrefab; // Key prefab to be destroyed

    private bool hasKey = false; // Flag to track if the player has the key

    void Update()
    {
        // Check if the player is pressing the pickup key and has not yet picked up the key
        if (Input.GetKeyDown(pickupKey) && !hasKey)
        {
            // Set hasKey to true
            hasKey = true;

            // Deactivate the current trigger
            currentTrigger.SetActive(false);

            // Activate the next trigger
            nextTrigger.SetActive(true);

            // Destroy the key prefab
            Destroy(keyPrefab);
        }
    }
/*
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the key
        if (other.gameObject.CompareTag("Key"))
        {
            // Enable a prompt or UI to inform the player they can pick up the key
            Debug.Log("Press 'E' to pick up the key!");

            // Assign the current trigger and next trigger
            currentTrigger = GameObject.FindGameObjectWithTag("CurrentTrigger");
            nextTrigger = GameObject.FindGameObjectWithTag("NextTrigger");

            // Assign the key prefab
            keyPrefab = other.gameObject;

        }
    }*/
}
