using UnityEngine;

// Item used to progress through the level

[CreateAssetMenu]
public class InventoryObject : ScriptableObject
{
    public string itemName;

    // Not in use yet
    public Sprite icon;
    public string flavourText; // Maybe not necessary?
}
