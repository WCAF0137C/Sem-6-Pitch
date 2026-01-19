using UnityEngine;

public class DialogueSpot : MonoBehaviour
{
    LevelManager levelManager;
    DialogueSystem dialogueSystem;

    public Conversation conversation;
    //public GameObject mesh;

    bool playerIsPresent = false;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        dialogueSystem = GameObject.FindGameObjectWithTag("DialogueSystem").GetComponent<DialogueSystem>();
    }

    void Update()
    {
        if (playerIsPresent)
        {
            // Change a HUD prompt
        }
        if (playerIsPresent && Input.GetKeyDown(KeyCode.E) && !GameManager.Instance.gamePaused && !GameManager.Instance.cameraPaused)
        {
            dialogueSystem.StartDialogue(conversation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsPresent = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsPresent = false;
        }
    }
}
