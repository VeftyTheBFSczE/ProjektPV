using UnityEngine;

public class DialogTriggerKonec : MonoBehaviour
{
    public Dialog dialogManager; // Reference to the DialogManager

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Check if the dialogManager reference is assigned
            if (dialogManager != null)
            {
                // Start the dialog
                dialogManager.StartDialog();
            }
            else
            {
                Debug.LogWarning("DialogManagerKonec reference is not assigned in t Inspecto!");
            }
        }
    }
}
