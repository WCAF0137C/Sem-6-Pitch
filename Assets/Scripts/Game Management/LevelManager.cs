using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    // List of inventory objects (These are on a per-level currently. Help change this if necessary if pitch gets selected)
    // List of clues/evidence objects
    // List of... questions?

    public List<EvidenceObject> evidenceList = new List<EvidenceObject>();
    public List<InventoryObject> inventoryList = new List<InventoryObject>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
