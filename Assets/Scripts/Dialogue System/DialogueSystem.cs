using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    // Dialogue system lives here. I have one day left and am desperate for time, this won't be pretty

    public GameObject dialogueCanvas;

    public TextMeshProUGUI dialogueText;
    public Conversation currentConversation;
    public float textSpeed; // Time between characters

    int index;

    void Start()
    {
        dialogueText.text = string.Empty;

        dialogueCanvas.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.runningDialogue && Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == currentConversation.lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = currentConversation.lines[index];
            }
        }
    }

    public void StartDialogue(Conversation conversation)
    {
        currentConversation = conversation;

        dialogueCanvas.SetActive (true);
        dialogueText.text = string.Empty;

        GameManager.Instance.StartDialogue();
        GameManager.Instance.PauseCamera();

        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentConversation.lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < currentConversation.lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueCanvas.SetActive(false);
            GameManager.Instance.EndDialogue();
            GameManager.Instance.UnpauseCamera();
        }
    }
}
