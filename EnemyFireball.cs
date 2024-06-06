using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public GameObject fireballPrefab; // Prefab of the fireball
    public Transform firePoint; // Point from where the fireball will be spawned
    public float fireballSpeed = 10f; // Speed of the fireball

    private void Start()
    {
        // Invoke the method to throw fireball repeatedly
        InvokeRepeating("ThrowFireball", 1f, 2f); // Change the delay and repeat rate as needed
    }

    private void ThrowFireball()
    {
        // Instantiate the fireball prefab at the fire point position and rotation
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the fireball
        Rigidbody rb = fireball.GetComponent<Rigidbody>();

        // Check if the Rigidbody component is not null
        if (rb != null)
        {
            // Set the velocity of the fireball to move forward
            rb.velocity = firePoint.forward * fireballSpeed;
        }
    }

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
        // Example: Restart the level or perform other actions
        Debug.Log("Player defeated!");
        // You can implement game over logic here
    }
}
