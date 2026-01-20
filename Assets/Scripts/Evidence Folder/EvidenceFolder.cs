using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class EvidenceFolder : MonoBehaviour
{
    //This script functions as a menu system for our evidence folder
    public GameObject folderCanvas; // Animate later
    bool menuIsOpen = false;
    LevelManager levelManager;

    // Clues section
    public GameObject clueOverviewPanel;
    public GameObject clueDetailsPanel;
    public GameObject clueReturnButton;

    // Clue details subection
    public TextMeshProUGUI clueDetailsTitle;
    public TextMeshProUGUI clueDetailsDescription;

    public List<GameObject> evidenceSlots;

    // Info section
    public GameObject reportPanel;
    public GameObject questionsPanel;
    public GameObject inventoryPanel;

    //public Button reportButton;
    //public Button questionsButton;
    //public Button inventoryButton;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        clueOverviewPanel.SetActive(true);
        clueDetailsPanel.SetActive(false);

        clueReturnButton.SetActive(false);

        reportPanel.SetActive(true);
        questionsPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        // Run through evidence and allot the correct amount of clue slots
        for (int i = 0; i < evidenceSlots.Count; i++)
        {
            evidenceSlots[i].GetComponentInChildren<Button>().interactable = false;

            if (i < levelManager.evidenceList.Count)
            {
                evidenceSlots[i].SetActive(true);
            }
            else
            {
                evidenceSlots[i].SetActive(false);
            }
        }

        folderCanvas.SetActive(false); // Animate later
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !GameManager.Instance.gamePaused && !GameManager.Instance.runningDialogue) // This will need to be changed so a button can affect it later if controller support is desired
        {
            if (menuIsOpen)
            {
                CloseMenu();
                GameManager.Instance.UnpauseCamera();
            }
            else
            {
                OpenMenu();
                GameManager.Instance.PauseCamera();
            }
        }
        else if (GameManager.Instance.gamePaused && folderCanvas.activeSelf)
        {
            CloseMenu();
            GameManager.Instance.UnpauseCamera();
        }
        else if (GameManager.Instance.runningDialogue && folderCanvas.activeSelf)
        {
            CloseMenu();
            // Unpause camera is missing because the dialogue system script should pause it instead
            // Theoretically, this should never happen unless we trigger a call when we're in this menu
            // But hey, that's what failsafes are for, right?
        }

        // THERE ARE DEFINITELY BETTER WAYS TO DO THIS
        int activeSlots = 0;
        for (int i = 0; i < evidenceSlots.Count; i++)
        {
            if (evidenceSlots[i].activeInHierarchy)
            {
                activeSlots += 1;
            }
        }

        for (int i = 0; i < activeSlots; i++)
        {
            if (levelManager.evidenceList[i].clueFound && !evidenceSlots[i].GetComponentInChildren<Button>().interactable)
            {
                evidenceSlots[i].GetComponentInChildren<Button>().interactable = true;
                TextMeshProUGUI[] textList = evidenceSlots[i].GetComponentsInChildren<TextMeshProUGUI>();
                textList[0].text = levelManager.evidenceList[i].name;
                textList[1].text = levelManager.evidenceList[i].flavourText;
            }
        }
    }

    // Menu navigation
    public void OpenMenu()
    {
        menuIsOpen = true;
        folderCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        // Reset folder pages to defaults?
        ClueOverviewButton();
        //ReportButton();
    }

    public void CloseMenu()
    {
        menuIsOpen = false;
        folderCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        // Need to change camera/cursor control value in game manager
    }

    public void ClueOverviewButton()
    {
        clueOverviewPanel.SetActive(true);
        clueDetailsPanel.SetActive(false);
        clueReturnButton.SetActive(false);
    }

    public void ClueDetails(EvidenceObject clue) // Currently unused, gonna need to be accessed by specific clue buttons. Maybe take info from scriptable objects?
    {
        clueOverviewPanel.SetActive(false);
        clueDetailsPanel.SetActive(true);
        clueReturnButton.SetActive(true);

        clueDetailsTitle.text = clue.name;
        clueDetailsDescription.text = clue.fullDescription;
    }

    public void ClueDetailsButton(int slotID)
    {
        ClueDetails(levelManager.evidenceList[slotID]);
    }

    public void ReportButton()
    {
        reportPanel.SetActive(true);
        questionsPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    public void QuestionsButton()
    {
        reportPanel.SetActive(false);
        questionsPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    public void InventoryButton()
    {
        reportPanel.SetActive(false);
        questionsPanel.SetActive(false);
        inventoryPanel.SetActive(true);
    }
}
