using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // TextMeshProUGUI komponenta pro zobrazení dialogu
    public Button nextButton;          // UI Button komponenta pro pokračování v dialogu

    private string[] dialogLines;      // Pole řádků dialogu
    private int currentLineIndex;      // Aktuální index řádku dialogu

    void Start()
    {
        // Ujistěte se, že kurzor je viditelný
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Inicializace dialogových řádků
        dialogLines = new string[]
        {
            "Me: Where am i?",
            "??: Come closer",
            "Me: Who is it!!!",
            "??: There is something i want to show you",
            "Me: Where?",
            "??: Here at the arcade machine come closer"
        };

        // Skryjte dialogové UI na začátku
        dialogText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        // Přidání listeneru pro tlačítko
        nextButton.onClick.AddListener(OnNextButtonClicked);

   
    }

    public void StartDialog()
    {
        Debug.Log("Starting dialog...");
        
        // Ujistěte se, že kurzor je viditelný, když dialog začne
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Reset dialogu
        currentLineIndex = 0;
        ShowCurrentLine();

        // Zobrazení dialogového UI
        dialogText.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }

    void ShowCurrentLine()
    {
        Debug.Log("Showing line: " + currentLineIndex);
        
        if (currentLineIndex < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLineIndex];
        }
        else
        {
            dialogText.text = "Konec dialogu.";
            nextButton.gameObject.SetActive(false); // Skrytí tlačítka po dokončení dialogu
        }
    }

    void OnNextButtonClicked()
    {
        currentLineIndex++;
        ShowCurrentLine();

        // Skryjte dialogové UI a kurzor po dokončení dialogu
        if (currentLineIndex >= dialogLines.Length)
        {
            dialogText.gameObject.SetActive(false);
            Cursor.visible = false;
        }
    }
}
