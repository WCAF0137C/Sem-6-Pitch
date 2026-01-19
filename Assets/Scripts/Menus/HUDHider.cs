using UnityEngine;

public class HUDHider : MonoBehaviour
{
    // This script is just for ease of editor use so that the canvases don't get in the way. I did not think ahead.

    public GameObject hudAndWhatnot;

    void Start()
    {
        hudAndWhatnot.SetActive(true);
    }

    void Update()
    {
        
    }
}
