using UnityEngine;

public class Orb : MonoBehaviour
{
    public float jumpBoostForce = 15f; // The additional force to add to the player's jump when boosted

    private bool hasBeenCollected = false; // Flag to track whether the orb has been collected

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenCollected && other.CompareTag("Player"))
        {
            // Get the PlayerMovement3D script attached to the player
            PlayerMovement3D playerMovement = other.GetComponent<PlayerMovement3D>();

            if (playerMovement != null)
            {
                // Apply the jump boost to the player
                playerMovement.ApplyJumpBoost(jumpBoostForce);

                // Set the flag to indicate the orb has been collected
                hasBeenCollected = true;

                // Destroy the orb after collection
                Destroy(gameObject);
            }
        }
    }
}
