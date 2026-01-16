using UnityEngine;
using UnityEngine.UI;

public class EvidenceFolder : MonoBehaviour
{
    public enum CluesEnum
    {
        Overview,
        Details
    }

    public enum InfoEnum
    {
        Report,
        Questions,
        Inventory
    }

    //This script functions as a menu system for our evidence folder
    public GameObject folderCanvas; // Animate later
    bool menuIsOpen = false;

    // Clues section
    public GameObject clueOverviewPanel;
    public GameObject clueDetailsPanel;
    //public Button clueReturnButton;

    private CluesEnum currentCluePanel = CluesEnum.Overview;

    // Info section
    public GameObject reportPanel;
    public GameObject questionsPanel;
    public GameObject inventoryPanel;

    //public Button reportButton;
    //public Button questionsButton;
    //public Button inventoryButton;

    private InfoEnum currentInfoPanel = InfoEnum.Report;

    void Start()
    {
        clueOverviewPanel.SetActive(true);
        clueDetailsPanel.SetActive(false);

        reportPanel.SetActive(true);
        questionsPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        folderCanvas.SetActive(false); // Animate later
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // This will need to be changed so a button can affect it later if controller support is desired
        {
            if (menuIsOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        menuIsOpen = true;
        folderCanvas.SetActive(true);

        // Reset folder pages to defaults?
        ClueOverviewButton();
        ReportButton();

        // Need to change camera/cursor control value in game manager
    }

    public void CloseMenu()
    {
        menuIsOpen = false;
        folderCanvas.SetActive(false);

        // Need to change camera/cursor control value in game manager
    }

    public void ClueOverviewButton()
    {
        clueOverviewPanel.SetActive(true);
        clueDetailsPanel.SetActive(false);

        currentCluePanel = CluesEnum.Overview;
    }

    public void ClueDetailsButton() // Currently unused, gonna need to be accessed by specific clue buttons. Maybe take info from scriptable objects?
    {
        clueOverviewPanel.SetActive(false);
        clueDetailsPanel.SetActive(true);

        currentCluePanel = CluesEnum.Details;
    }

    public void ReportButton()
    {
        reportPanel.SetActive(true);
        questionsPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        currentInfoPanel = InfoEnum.Report;
    }

    public void QuestionsButton()
    {
        reportPanel.SetActive(false);
        questionsPanel.SetActive(true);
        inventoryPanel.SetActive(false);

        currentInfoPanel = InfoEnum.Questions;
    }

    public void InventoryButton()
    {
        reportPanel.SetActive(false);
        questionsPanel.SetActive(false);
        inventoryPanel.SetActive(true);

        currentInfoPanel = InfoEnum.Inventory;
    }
}
