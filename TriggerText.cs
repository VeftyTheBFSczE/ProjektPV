using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign this in the Inspector
    public Transform spawnLocation; // Set this to the desired spawn location
    public string message = "Trigger entered"; // Message to display
    public Material GlowEffectMaterial; // Add this line to your script


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player has a tag named "Player"
        {
            Debug.Log(message); // Displaying the message in the console
            SpawnObjectWithGlow();
        }
    }

    private void SpawnObjectWithGlow()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
        Renderer renderer = spawnedObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Directly assign the glow effect material to the spawned object
            renderer.material = GlowEffectMaterial;
        }
    }
}
