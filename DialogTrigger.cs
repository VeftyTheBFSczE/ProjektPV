using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogManager dialogManager; // Reference to the DialogManager

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        
        // Check if the player has entered the trigger zone
        if (other.CompareTag("Player"))
        {
            // Start the dialog
            dialogManager.StartDialog();
        }
    }
}
