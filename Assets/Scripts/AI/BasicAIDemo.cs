using UnityEngine;
using UnityEngine.AI;

public class BasicAIDemo : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject donutSpot; // InventoryPlacement object check
    public bool distracted = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!distracted && donutSpot.GetComponent<InventoryPlacement>().isComplete)
        {
            distracted = true;
            agent.SetDestination(donutSpot.transform.position);
        }
    }
}
