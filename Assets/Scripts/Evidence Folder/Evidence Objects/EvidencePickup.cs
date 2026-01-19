using UnityEngine;

public class EvidencePickup : MonoBehaviour
{
    LevelManager levelManager;

    public EvidenceObject evidenceItem; // The scriptable object that will be added to the clue list
    public GameObject mesh;

    bool playerIsPresent = false;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    void Update()
    {
        if (playerIsPresent)
        {
            // Change a HUD prompt
        }
        if (playerIsPresent && Input.GetKeyDown(KeyCode.E) && mesh.activeInHierarchy && !GameManager.Instance.gamePaused && !GameManager.Instance.cameraPaused)
        {
            mesh.SetActive(false);

            levelManager.evidenceList.Add(evidenceItem); // Add the object to the evidence list. Need to alter how this works so that clues can be uncovered
            // Maybe search the evidence list for a clue with the same name and toggle it to be on/found.
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
