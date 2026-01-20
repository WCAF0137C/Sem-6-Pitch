using UnityEngine;

// Evidence or clues used to answer questions from dropdowns in your evidence folder

[CreateAssetMenu]
public class EvidenceObject : ScriptableObject
{
    public bool clueFound = false; // Will enable other clue information in the case file
    public string itemName;
    public string flavourText;
    [TextArea(15, 20)]
    public string fullDescription;

    // Not in use yet
    public Sprite icon;
}
