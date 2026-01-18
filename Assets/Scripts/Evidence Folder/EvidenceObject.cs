using UnityEngine;

// Evidence or clues used to answer questions from dropdowns in your evidence folder

[CreateAssetMenu]
public class EvidenceObject : ScriptableObject
{
    public string itemName;
    public bool clueFound; // Will enable other clue information in the case file

    // Not in use yet
    public Sprite icon;
    public string flavourText; // Maybe not necessary?
}
