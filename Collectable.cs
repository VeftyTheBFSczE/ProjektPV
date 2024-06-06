using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        // Find the GameManager script in the scene
        gameManager = FindObjectOfType<GameManager>();

        // Check if the GameManager script is found
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Call the CollectItem method of the GameManager script
            if (gameManager != null)
            {
                gameManager.CollectItem();
            }

            // Disable the collectible item
            gameObject.SetActive(false);
        }
    }
}
