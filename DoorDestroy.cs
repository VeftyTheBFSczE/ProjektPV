using UnityEngine;

public class DoorDestroy : MonoBehaviour
{
    public KeyCode destroyKey = KeyCode.E; // Key to destroy the door
    public GameObject door; // Reference to the door GameObject

    private bool doorTriggered = false; // Flag to track if the door has been triggered

    void Update()
    {
        // Check if the door has been triggered and the player is pressing the destroy key
        if (doorTriggered && Input.GetKeyDown(destroyKey))
        {
            // Destroy the door GameObject
            Destroy(door);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            // Enable a prompt or UI to inform the player they can destroy the door
            Debug.Log("Press 'E' to destroy the door!");

            // Set the door triggered flag to true
            doorTriggered = true;
        }
    }
}
