using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        GameManager.Instance.UnpauseGame(); // Need to set the game to unpaused at the start of every scene!
    }

    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene"); // Load the sandbox
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quitting!"); // Editor-only message
    }
}
