using UnityEngine;
using UnityEngine.AI;
public class NPCMovement : MonoBehaviour 
{
    public GameObject targetGo;
    private NavMeshAgent navMeshAgent;
    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update (){
        HeadForDestintation();
    }

    private void HeadForDestintation () {
        Vector3 destination = targetGo.transform.position;
        navMeshAgent.SetDestination (destination);
    }
}

