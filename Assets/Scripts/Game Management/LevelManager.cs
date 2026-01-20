using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    // List of inventory objects (These are on a per-level currently. Help change this if necessary if pitch gets selected)
    // List of clues/evidence objects
    // List of... questions?

    public List<InventoryObject> inventoryList = new List<InventoryObject>();
    public List<EvidenceObject> evidenceList = new List<EvidenceObject>();

    void Start()
    {
        for (int i = 0; i < evidenceList.Count; i++) // This is another one of those patchwork solutions that I really wouldn't normally advise
        {
            evidenceList[i].clueFound = false;
        }
    }

    void Update()
    {
        
    }
}
