using UnityEngine;

// Game manager template copied off of Unity forums somewhere
public class GameManager
{
    private static GameManager instance;

    public bool cameraPaused = false;
    public bool gamePaused = false;
    public bool runningDialogue;

    // Handle memory between scenes/gameplay sessions here later? (Only if pitch gets picked)

    private GameManager()
    {
        // Initialize your game manager here. Do not reference to GameObjects here (i.e. GameObject.Find etc.)
        // Because the game manager will be created before the objects
    }

    public static GameManager Instance // Reference this with a capital letter
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public void PauseGame() // Potentially have this affect timescale?
    {
        if (!gamePaused)
        {
            gamePaused = true;
            Time.timeScale = 0f;
        }
    }

    public void UnpauseGame() // Potentially have this affect timescale?
    {
        if (gamePaused)
        {
            gamePaused = false;
            Time.timeScale = 1f;
        }
    }

    public void PauseCamera()
    {
        if (!cameraPaused)
        {
            cameraPaused = true;
        }
    }

    public void UnpauseCamera()
    {
        if (cameraPaused)
        {
            cameraPaused = false;
        }
    }

    public void StartDialogue()
    {
        runningDialogue = true;
    }

    public void EndDialogue()
    {
        runningDialogue = false;
    }
}
