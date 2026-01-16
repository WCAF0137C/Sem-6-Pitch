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

    // Clues section
    public GameObject clueOverviewPanel;
    public GameObject clueDetailsPanel;
    public Button clueReturnButton;

    public CluesEnum currentCluePanel = CluesEnum.Overview;

    // Info section
    public GameObject reportPanel;
    public GameObject questionsPanel;
    public GameObject inventoryPanel;

    public Button reportButton;
    public Button questionsButton;
    public Button inventoryButton;

    public InfoEnum currentInfoPanel = InfoEnum.Report;

    void Start()
    {
        questionsPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        folderCanvas.SetActive(false); // Animate later
    }

    void Update()
    {
        
    }
}
