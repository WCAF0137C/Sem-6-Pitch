using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        GameManager.Instance.UnpauseGame(); // Need to set the game to unpaused at the start of every scene!
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.Instance.gamePaused)
            {
                GameManager.Instance.PauseGame();
            }
            else if (GameManager.Instance.gamePaused)
            {
                GameManager.Instance.UnpauseGame();
            }
        }

        if (!GameManager.Instance.gamePaused && pauseMenu.activeSelf) // Hide pause menu if unpaused
        {
            pauseMenu.SetActive(false);
        }
        else if (GameManager.Instance.gamePaused && !pauseMenu.activeSelf) // Show pause menu if paused
        {
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeButton()
    {
        GameManager.Instance.UnpauseGame();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu"); // Load the sandbox
    }
}
