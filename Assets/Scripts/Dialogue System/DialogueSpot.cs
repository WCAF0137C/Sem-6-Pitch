using UnityEngine;

public class DialogueSpot : MonoBehaviour
{
    // THIS SCRIPT IS VERY BASIC IN FUNCTION RIGHT NOW
    // My recommendation is to either make it trigger an event after completing a bit of dialogue,
    // or to treat it as a simple hint/guidance point in the level.

    LevelManager levelManager;
    public DialogueSystem dialogueSystem;

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
