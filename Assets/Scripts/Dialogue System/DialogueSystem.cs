using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    // Dialogue system lives here. I have one day left and am desperate for time, this won't be pretty

    public GameObject dialoguePanel;

    public TextMeshProUGUI dialogueText;
    //public string[] lines; // Temp. Need to read lines from a scriptable object
    public Conversation currentConversation;
    public float textSpeed; // Time between characters

    int index;

    void Start()
    {
        dialogueText.text = string.Empty;

        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

        dialoguePanel.SetActive (true);
        dialogueText.text = string.Empty;

        GameManager.Instance.StartDialogue();

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
            dialoguePanel.SetActive(false);
            GameManager.Instance.EndDialogue();
        }
    }
}
