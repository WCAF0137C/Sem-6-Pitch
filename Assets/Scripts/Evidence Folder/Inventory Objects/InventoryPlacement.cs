using UnityEngine;

public class InventoryPlacement : MonoBehaviour
{
    LevelManager levelManager;

    public InventoryObject requiredItem; // The item needed to activate the thingy
    public GameObject mesh;
    public bool isComplete = false; // The rudimentary AI will need this

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
        if (playerIsPresent && Input.GetKeyDown(KeyCode.E) && !mesh.activeInHierarchy && levelManager.selectedObject == requiredItem
            && !GameManager.Instance.gamePaused && !GameManager.Instance.cameraPaused)
        {
            mesh.SetActive(true);

            levelManager.selectedObject = null;
            levelManager.inventoryList.Remove(requiredItem); // Add the object to the inventory;

            isComplete = true;
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
