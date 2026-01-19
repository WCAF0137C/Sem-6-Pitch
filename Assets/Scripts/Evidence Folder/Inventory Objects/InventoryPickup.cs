using UnityEngine;

public class InventoryPickup : MonoBehaviour
{
    LevelManager levelManager;

    public InventoryObject inventoryItem; // The scriptable object that will be added to the inventory
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

            levelManager.inventoryList.Add(inventoryItem); // Add the object to the inventory;
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
